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
            Debug.Log("Q pressed �� Life Reduced");
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.IncreaseLife();
            Debug.Log("E pressed �� Life Increased");
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            uiManager.UseLaser();
            Debug.Log("A pressed �� Laser Used");
        }

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            uiManager.RechargeLaser();
            Debug.Log("D pressed �� Laser Recharged");
        }

        
        if (Input.GetKeyDown(KeyCode.K))
        {
            uiManager.DefeatBoss();
            Debug.Log("K pressed �� Boss Defeated");
        }
    }
}
