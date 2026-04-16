using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [Header("ไฟล์เสียงเดินแต่ละพื้นผิว")]
    public AudioClip grassStep;
    public AudioClip snowStep;
    public AudioClip woodStep;
    public AudioClip stoneStep;

    [Header("ตั้งค่าการก้าวเดิน")]
    public float stepInterval = 0.4f; // ระยะเวลาต่อ 1 ก้าว (ปรับให้ตรงกับความเร็วการเดิน)
    private float stepTimer;

    private AudioSource audioSource;
    private Rigidbody rb; // ใช้สำหรับเช็คว่าตัวละครกำลังขยับอยู่ไหม

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // เช็คว่าผู้เล่นกำลังเคลื่อนที่อยู่หรือไม่ (ความเร็วมากกว่า 0.1)
        bool isMoving = rb != null && rb.linearVelocity.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            // ถ้าเวลานับถอยหลังถึง 0 ให้เล่นเสียง 1 ครั้ง
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // รีเซ็ตเวลานับใหม่
            }
        }
        else
        {
            // ถ้าหยุดเดิน ให้รีเซ็ตเวลาเป็น 0 พอเริ่มเดินใหม่จะได้มีเสียงทันที
            stepTimer = 0f;
        }
    }

    void PlayFootstepSound()
    {
        // ยิงเลเซอร์ (Raycast) ลงไปใต้เท้าเพื่อดูว่าเหยียบพื้นอะไรอยู่
        RaycastHit hit;
        // ระยะ 1.5f อาจจะต้องปรับเพิ่ม/ลด ขึ้นอยู่กับความสูงของตัวละครคุณ
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            string groundTag = hit.collider.tag;

            // เลือกเล่นเสียงตาม Tag ของพื้น
            switch (groundTag)
            {
                case "Grass":
                    audioSource.PlayOneShot(grassStep);
                    break;
                case "Snow":
                    audioSource.PlayOneShot(snowStep);
                    break;
                case "Wood":
                    audioSource.PlayOneShot(woodStep);
                    break;
                case "Stone":
                    audioSource.PlayOneShot(stoneStep);
                    break;
                default:
                    // ถ้าพื้นไม่มี Tag เลย หรือเป็นชื่ออื่น ให้ใช้เสียงหินเป็นเสียงพื้นฐาน
                    audioSource.PlayOneShot(stoneStep);
                    break;
            }
        }
    }
}