using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float scrollSpeed = 1.2f;
    private Renderer thisRenderer;

    public Material backgroundMaterial1; 
    public Material backgroundMaterial2; 

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        thisRenderer.material = backgroundMaterial1; 
    }

    void Update()
    {
        if (UIManager.isWaitingForStart) return;

        Vector2 newOffset = thisRenderer.material.mainTextureOffset;
        newOffset.x += scrollSpeed * Time.deltaTime;
        thisRenderer.material.mainTextureOffset = newOffset;
    }

    // 배경 변경 함수 추가
    public void ChangeBackground(int stage)
    {
        if (stage == 1)
        {
            thisRenderer.material = backgroundMaterial1; 
        }
        else if (stage == 2)
        {
            thisRenderer.material = backgroundMaterial2; 
        }
    }
}
    
