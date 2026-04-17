using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // เพิ่มฟังก์ชัน Start นี้เข้าไปครับ (มันจะทำงานอัตโนมัติทันทีที่หน้าเมนูเปิดขึ้นมา)
    void Start()
    {
        // 1. ปลดล็อกเมาส์ให้ขยับไปมาบนหน้าจอได้
        Cursor.lockState = CursorLockMode.None;

        // 2. สั่งให้โชว์ลูกศรเมาส์ขึ้นมา
        Cursor.visible = true;

        // 3. กันเหนียว เผื่อเวลาในเกมยังโดนหยุดอยู่
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        Debug.Log("กำลังโหลดเข้าเกม...");
        SceneManager.LoadScene("Map1"); // ชื่อ Scene ด่านของคุณ
    }

    public void QuitGame()
    {
        Debug.Log("ออกจากเกมแล้ว!");
        Application.Quit();
    }
}