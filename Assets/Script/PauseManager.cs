using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;

    // สร้างตัวแปรมาคอยจำว่าตอนนี้เกมหยุดอยู่ไหม (เสถียรกว่าการเช็ค Time.timeScale)
    private bool isPaused = false;

    void Start()
    {
        // เริ่มเกมมาให้แน่ใจว่าเวลาเดินปกติ และซ่อนหน้าต่างไว้
        Time.timeScale = 1f;
        isPaused = false;
        if (pauseScreen != null) pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("เกมหยุดแล้ว!"); // ส่งข้อความบอกใน Console
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("กดปุ่มสำเร็จ! เกมกลับมาเล่นต่อแล้ว!"); // ส่งข้อความบอกใน Console
    }
}