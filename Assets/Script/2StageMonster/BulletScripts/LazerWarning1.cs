using TMPro;
using UnityEngine;

public class LazerWarning2 : MonoBehaviour
{
    public float lerpTime = 1f;

    SpriteRenderer spriteRenderer;
    Transform LazerPos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        LazerPos = GameObject.Find("Goru").GetComponent<Goru>().Pos[2];
    }

    private void Update()
    {
        transform.position = LazerPos.position;
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
