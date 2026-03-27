using UnityEngine;
using System.Collections;

public class AutoSequenceBlink : MonoBehaviour
{
    [Header("ตั้งค่าจังหวะคลื่น")]
    [Tooltip("ระยะห่างเวลาระหว่างกล่องแต่ละใบ (เช่น 0.2 คือกล่องถัดไปจะเริ่มช้าลง 0.8 วิ)")]
    public float stepDelay = 3f;

    [Header("ตั้งค่าเวลาแสดงผล")]
    public float appearTime = 4f;
    public float disappearTime = 3f;

    private Renderer platformRenderer;
    private Collider platformCollider;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();

        if (platformRenderer != null && platformCollider != null)
        {
            // เริ่มการคำนวณลำดับอัตโนมัติ
            StartCoroutine(BlinkRoutine());
        }
    }

    IEnumerator BlinkRoutine()
    {
        // --- ส่วนที่เป็น Auto-Sequence ---
        // transform.GetSiblingIndex() จะคืนค่าลำดับของ Object ใน Hierarchy (เริ่มจาก 0)
        int myOrder = transform.GetSiblingIndex();
        float calculatedDelay = myOrder * stepDelay;

        // รอตามลำดับที่คำนวณได้
        yield return new WaitForSeconds(calculatedDelay);
        // --------------------------------

        while (true)
        {
            // ปรากฏ
            SetPlatformActive(true);
            yield return new WaitForSeconds(appearTime);

            // หายไป
            SetPlatformActive(false);
            yield return new WaitForSeconds(disappearTime);
        }
    }

    void SetPlatformActive(bool state)
    {
        platformRenderer.enabled = state;
        platformCollider.enabled = state;
    }
}