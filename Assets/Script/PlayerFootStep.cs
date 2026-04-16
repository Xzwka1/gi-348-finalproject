using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    // ลบตัวแปรเสียง 4 อันบนสุดทิ้งไปได้เลยครับ เพราะเราไปฝากไว้ที่ Manager แล้ว!

    [Header("ตั้งค่าการก้าวเดิน")]
    public float stepInterval = 0.4f;
    private float stepTimer;
    private AudioSource audioSource;
    private bool wasGrounded = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // (โค้ดใน Update ใช้ของเดิมเป๊ะๆ เลยครับ ไม่ต้องแก้)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        bool isPressingMove = Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f;
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.3f);

        if (!wasGrounded && isGrounded)
        {
            PlayFootstepSound();
        }

        if (isPressingMove && isGrounded)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        wasGrounded = isGrounded;
    }

    void PlayFootstepSound()
    {
        Vector3 rayStart = transform.position + (Vector3.up * 0.5f);
        RaycastHit hit;

        if (Physics.Raycast(rayStart, Vector3.down, out hit, 1.5f))
        {
            string groundTag = hit.collider.tag;

            // --- ความฉลาดอยู่ตรงนี้! ---
            // เดินไปบอก FootstepManager ว่า "ขอเสียงของ Tag นี้หน่อย!"
            if (FootstepManager.instance != null)
            {
                AudioClip soundToPlay = FootstepManager.instance.GetSoundForSurface(groundTag);
                PlayClip(soundToPlay);
            }
            // ------------------------
        }
    }

    void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}