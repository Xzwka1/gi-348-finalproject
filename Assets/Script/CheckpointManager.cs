using UnityEngine;
using TMPro;
using System.Collections;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public TextMeshProUGUI saveText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        // แก้จาก gameObject.SetActive เป็น enabled เพื่อซ่อนแค่ภาพ แต่สคริปต์ยังทำงานอยู่
        if (saveText != null) saveText.enabled = false;
    }

    public void ShowSaveText()
    {
        StartCoroutine(ShowTextRoutine());
    }

    IEnumerator ShowTextRoutine()
    {
        // เปิดให้ตัวหนังสือมองเห็น
        saveText.enabled = true;

        yield return new WaitForSeconds(2f); // โชว์ค้างไว้ 2 วินาที

        // ซ่อนตัวหนังสือกลับไปเหมือนเดิม
        saveText.enabled = false;
    }
}