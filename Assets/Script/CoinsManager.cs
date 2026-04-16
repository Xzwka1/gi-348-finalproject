using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // ⚠️ ต้องมีบรรทัดนี้ เพื่อใช้คำสั่งเปลี่ยนฉาก

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("UI และคะแนน")]
    public TextMeshProUGUI coinText;
    private int score = 0;

    [Header("ระบบจบเกม")]
    public int winScore = 6; // จำนวนดาวที่ต้องเก็บให้ครบ
    public string nextSceneName = "WinScene"; // ชื่อ Scene หน้าจบเกม (พิมพ์ให้ตรงเป๊ะ)

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddCoin(int amount)
    {
        score += amount;
        UpdateUI();

        // เช็คว่าคะแนนถึงที่กำหนดหรือยัง
        if (score >= winScore)
        {
            GoToNextScene();
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + score.ToString();
        }
    }

    void GoToNextScene()
    {
        Debug.Log("เก็บครบ 6 อันแล้ว! กำลังโหลดหน้าจบเกม...");
        // คำสั่งเปลี่ยนฉากไปยังหน้าจบเกม
        SceneManager.LoadScene(nextSceneName);
    }
}