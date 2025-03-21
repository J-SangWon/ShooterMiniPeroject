using TMPro;
using UnityEngine;

public class LazerWarning : MonoBehaviour
{
    public float lerpTime = 1f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
       Invoke("ColorLerpLoop", 0);
    }

    void ColorLerpLoop()
    {
        spriteRenderer.color = Color.Lerp(new Color(0, 0, 0, 0), Color.red, 2);
    }
}
