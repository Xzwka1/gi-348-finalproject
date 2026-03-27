using UnityEngine;
using TMPro; // จำเป็นต้องใช้สำหรับ TextMeshPro

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // ทำให้สคริปต์อื่นเรียกใช้ง่ายๆ

    public TextMeshProUGUI coinText; // ลากตัวหนังสือจากหน้า UI มาใส่ช่องนี้
    private int score = 0;

    void Awake()
    {
        // สร้าง Singleton เพื่อให้เหรียญทุกใบส่งข้อมูลมาที่นี่ที่เดียว
        if (instance == null) instance = this;
    }

    public void AddCoin(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + score.ToString();
    }
}