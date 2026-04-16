using UnityEngine;

public class StarItem : MonoBehaviour
{
    [Header("ตั้งค่าดาว")]
    public int starValue = 1; // คะแนนที่ได้
    public float rotationSpeed = 100f; // ความเร็วในการหมุน

    void Update()
    {
        // ทำให้ดาวหมุนติ้วๆ ดูน่าเก็บ
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าคนที่มาชนคือผู้เล่นใช่ไหม?
        if (other.CompareTag("Player"))
        {
            // ส่งคะแนนไปให้ CoinManager (ใช้ระบบนับคะแนนเดิมที่เราเคยสร้างไว้ได้เลย)
            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddCoin(starValue);
            }
            else
            {
                Debug.LogWarning("หา CoinManager ไม่เจอ! อย่าลืมวาง CoinManager ไว้ในฉากนะครับ");
            }

            // เก็บเสร็จแล้ว ทำลายดาวทิ้ง
            Destroy(gameObject);
        }
    }
}