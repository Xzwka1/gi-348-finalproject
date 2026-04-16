using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ถ้าผู้เล่นตกลงมาโดนกล่องนี้ ให้เรียกฟังก์ชัน Respawn ให้วาร์ปกลับไปจุดเซฟ
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
        }
    }
}