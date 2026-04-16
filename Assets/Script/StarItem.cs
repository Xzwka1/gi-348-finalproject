using UnityEngine;

public class StarItem : MonoBehaviour
{
    [Header("ตั้งค่าดาว")]
    public int starValue = 1;
    public float rotationSpeed = 100f;

    [Header("ระบบเสียง")]
    public AudioClip collectSound; // เพิ่มช่องสำหรับใส่ไฟล์เสียงตอนเก็บ

    void Update()
    {
        // ทำให้ดาวหมุน
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // --- คำสั่งเล่นเสียงตอนเก็บ ---
            if (collectSound != null)
            {
                // PlayClipAtPoint จะสร้างจุดกำเนิดเสียงทิ้งไว้ตรงนี้ชั่วคราว แม้ตัวดาวจะถูกทำลายไปแล้วก็ตาม
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            // --------------------------

            // บวกคะแนน
            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddCoin(starValue);
            }

            // ทำลายดาวทิ้ง
            Destroy(gameObject);
        }
    }
}