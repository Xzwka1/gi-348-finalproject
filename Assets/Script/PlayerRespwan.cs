using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 currentRespawnPoint;

    void Start()
    {
        // ตอนเริ่มเกม ให้จำจุดเกิดแรกสุดเอาไว้ก่อน
        currentRespawnPoint = transform.position;
    }

    public void UpdateRespawnPoint(Vector3 newPoint)
    {
        currentRespawnPoint = newPoint;
        Debug.Log("เซฟจุดเกิดใหม่แล้วที่: " + currentRespawnPoint);
    }

    public void Respawn()
    {
        // ⚠️ การวาร์ปตัวละคร ต้องปิดระบบฟิสิกส์ชั่วคราวก่อน ไม่งั้นมันจะกระตุกกลับที่เดิม
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        // ย้ายกลับไปจุดเซฟ
        transform.position = currentRespawnPoint;

        if (cc != null) cc.enabled = true;

        // ถ้าระบบของคุณใช้ Rigidbody ให้รีเซ็ตความเร็วตอนตกด้วย
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = Vector3.zero;
    }
}