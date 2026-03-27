using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    [Header("ตั้งค่าการเคลื่อนที่")]
    [Tooltip("ระยะสูงสุดที่ต้องการให้ขยับขึ้นไปจากจุดเริ่มต้น")]
    public float distance = 3f;

    [Tooltip("ความเร็วในการเคลื่อนที่")]
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของ Object ไว้
        startPos = transform.position;
    }

    void Update()
    {
        // คำนวณค่าการขยับ (ขยับไป-กลับระหว่าง 0 ถึง distance)
        float movement = Mathf.PingPong(Time.time * speed, distance);

        // อัปเดตตำแหน่งเฉพาะแกน Y (ขึ้น-ลง)
        transform.position = startPos + new Vector3(0, movement, 0);
    }
}