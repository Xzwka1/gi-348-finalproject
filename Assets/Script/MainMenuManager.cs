using UnityEngine;
using UnityEngine.SceneManagement; // ⚠️ ต้องมีบรรทัดนี้ เพื่อให้สลับฉากได้

public class MainMenuManager : MonoBehaviour
{
    // ฟังก์ชันนี้จะถูกเรียกตอนกดปุ่ม Start
    public void PlayGame()
    {
        Time.timeScale = 1f;
        Debug.Log("กำลังโหลดเข้าเกม...");
        // ให้ใส่ชื่อ Scene เกมของคุณลงไปในวงเล็บ (ต้องสะกดให้ตรงเป๊ะ!)
        SceneManager.LoadScene("Map1"); // สมมติว่าฉากเกมชื่อ Map1
    }

    // ฟังก์ชันนี้จะถูกเรียกตอนกดปุ่ม Exit
    public void QuitGame()
    {
        Debug.Log("ออกจากเกมแล้ว!"); // เอาไว้เช็คใน Editor
        Application.Quit(); // คำสั่งปิดโปรแกรมเกม (ทำงานจริงตอนแพคเกมเป็น .exe แล้ว)
    }
}