using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isSaved = false; // ป้องกันการวิ่งไปมาแล้วเซฟซ้ำรัวๆ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSaved)
        {
            isSaved = true; // บันทึกว่าจุดนี้เคยเซฟไปแล้ว

            // สั่งให้ Player จำตำแหน่งใหม่ (ดึงตำแหน่งของกล่อง Empty Object นี้ไปใช้)
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                playerRespawn.UpdateRespawnPoint(transform.position);
            }

            // สั่งให้ UI โชว์ข้อความ Auto Save
            if (CheckpointManager.instance != null)
            {
                CheckpointManager.instance.ShowSaveText();
            }
        }
    }
}