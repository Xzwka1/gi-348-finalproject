using UnityEngine;

public class CoinItem : MonoBehaviour
{
    [Header("ตั้งค่าเหรียญ")]
    public int coinValue = 1; // 1 เหรียญมีค่าเท่าไหร่
    public float rotationSpeed = 100f; // ความเร็วในการหมุนของเหรียญ

    void Update()
    {
        // ทำให้เหรียญหมุนติ้วๆ จะได้ดูน่าเก็บ
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    // ฟังก์ชันทำงานเมื่อ Player วิ่งมาชน
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าสิ่งที่มาชนคือ "Player" หรือไม่ (อย่าลืมตั้ง Tag ที่ตัวละครว่า Player นะครับ)
        if (other.CompareTag("Player"))
        {
            // ส่งคะแนนไปที่ Manager
            CoinManager.instance.AddCoin(coinValue);

            // ลบเหรียญทิ้ง
            Destroy(gameObject);
        }
    }
}