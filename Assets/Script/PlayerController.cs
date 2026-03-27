using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    private int jumpCount = 0;

    [Header("Mouse Look")]
    public float mouseSensitivity = 200f;
    public Transform cameraPivot; // ลาก Camera Pivot มาใส่ในช่องนี้
    private float xRotation = 0f;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // ซ่อนเมาส์และล็อกไว้กลางจอเวลาเริ่มเกม
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ยิงลำแสงสั้นๆ ลงไปที่ใต้เท้าตัวละคร
        // 1.1f คือระยะความยาวลำแสง (ปรับตามความสูงตัวละคร)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded)
        {
            jumpCount = 0; // รีเซ็ตโดดถ้าแตะอะไรก็ตามที่อยู่ข้างล่าง
        }
        Look();
        Move();
        Jump();
    }

    void Look()
    {
        // รับค่าจากเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // หมุนตัวละคร ซ้าย-ขวา (แกน Y)
        transform.Rotate(Vector3.up * mouseX);

        // หมุนกล้อง ขึ้น-ลง (แกน X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // จำกัดมุมก้ม-เงย ไม่ให้กล้องตีลังกา
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        animator.SetFloat("InputX", moveX);
        animator.SetFloat("InputY", moveZ);

        // สำคัญ: เปลี่ยนจากการเดินตามแกนโลก เป็นเดินตามทิศที่ตัวละครหันหน้าไป
        Vector3 moveDirection = (transform.forward * moveZ + transform.right * moveX).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 velocity = moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + velocity);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpCount < maxJumps)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("jump");
                isGrounded = false;
                jumpCount++;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}