using UnityEngine;
using UnityEngine.SceneManagement; // จำเป็นต้องมีเพื่อใช้ระบบสลับฉาก
using System.Collections; // จำเป็นต้องมีเพื่อใช้ Coroutine

public class GameWinManager : MonoBehaviour
{
    // กำหนดเวลาหน่วงเป็นวินาที (ปรับแก้ได้ใน Unity Inspector)
    [Header("ตั้งค่าระบบสลับฉาก")]
    public float delayBeforeMenu = 2.0f; // ค่าเริ่มต้นคือ 2 วินาที

    // ฟังก์ชันนี้จะทำงานเมื่อหน้าจอ You Win ปรากฏขึ้น
    void Start()
    {
        // เริ่มต้น Coroutine เพื่อรอเวลาแล้วสลับฉาก
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    // Coroutine ที่จะทำงานหลังเวลาที่กำหนด
    IEnumerator LoadMainMenuAfterDelay()
    {
        // รอเวลาตามค่าใน delayBeforeMenu
        yield return new WaitForSeconds(delayBeforeMenu);

        // โหลดฉาก MainMenu (ตรวจสอบให้แน่ใจว่าชื่อฉากตรงกับใน Build Settings)
        Debug.Log("สลับไปหน้าเมนูหลัก!");
        SceneManager.LoadScene("MainMenu"); // แทนที่ "MainMenu" ด้วยชื่อฉากเมนูของคุณ
    }
}