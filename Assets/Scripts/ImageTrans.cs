using UnityEngine;
using UnityEngine.UI;

public class ImageFloat : MonoBehaviour
{
    public RectTransform imageTransform; // Drag the Image object to this field
    public float floatSpeed = 2.0f;      // ความเร็วในการขยับขึ้นลง
    public float floatRange = 10.0f;     // ระยะทางที่ขยับขึ้นลง

    private Vector2 originalPosition;

    void Start()
    {
        // บันทึกตำแหน่งเริ่มต้นของ Image
        originalPosition = imageTransform.anchoredPosition;
    }

    void Update()
    {
        // ใช้ sine wave เพื่อขยับขึ้นลง
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatRange;
        imageTransform.anchoredPosition = new Vector2(originalPosition.x, newY);
    }
}
