using UnityEngine;
using System.Collections.Generic;

// สร้างกลุ่มตัวแปร (Tag คู่กับ ไฟล์เสียง) ให้แสดงผลในหน้าต่าง Inspector ได้
[System.Serializable]
public struct SurfaceSound
{
    public string surfaceTag; // เอาไว้พิมพ์ชื่อ Tag เช่น "Grass", "Snow"
    public AudioClip stepSound; // เอาไว้ใส่ไฟล์เสียง
}

public class FootstepManager : MonoBehaviour
{
    public static FootstepManager instance; // ทำให้สคริปต์อื่นเรียกใช้ง่ายๆ (ตัวกลาง)

    [Header("คลังเก็บเสียงพื้นผิว")]
    // สร้าง List (รายการ) ที่เก็บคู่ของ Tag กับ เสียง
    public List<SurfaceSound> surfaceSounds = new List<SurfaceSound>();

    [Header("เสียงพื้นฐาน (ถ้าหา Tag ไม่เจอ)")]
    public AudioClip defaultSound;

    void Awake()
    {
        // ตั้งค่าตัวกลาง
        if (instance == null) instance = this;
    }

    // ฟังก์ชันนี้จะคอยรับชื่อ Tag จาก Player แล้วส่งไฟล์เสียงที่ตรงกันกลับไปให้
    public AudioClip GetSoundForSurface(string tagToFind)
    {
        // ค้นหาในโกดังเสียงของเรา
        foreach (SurfaceSound ss in surfaceSounds)
        {
            if (ss.surfaceTag == tagToFind)
            {
                return ss.stepSound; // เจอแล้ว! ส่งเสียงนี้กลับไป
            }
        }

        // ถ้าค้นจนจบแล้วไม่เจอ Tag ที่ตรงกันเลย ให้ส่งเสียงพื้นฐานกลับไปแทน
        return defaultSound;
    }
}