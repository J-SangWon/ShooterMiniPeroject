using UnityEngine;

public class TestController : MonoBehaviour
{
    public UIManager uiManager;               
    public BackgroundRepeat backgroundRepeat; 

    void Update()
    {
        if (UIManager.isWaitingForStart) return;

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            uiManager.ReduceLife();
            Debug.Log("Q pressed ¡æ Life Reduced");
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.IncreaseLife();
            Debug.Log("E pressed ¡æ Life Increased");
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            uiManager.UseLaser();
            Debug.Log("A pressed ¡æ Laser Used");
        }

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            uiManager.RechargeLaser();
            Debug.Log("D pressed ¡æ Laser Recharged");
        }

        
        if (Input.GetKeyDown(KeyCode.K))
        {
            uiManager.DefeatBoss();
            Debug.Log("K pressed ¡æ Boss Defeated");
        }
    }
}
