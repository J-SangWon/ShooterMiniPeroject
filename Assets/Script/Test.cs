using UnityEngine;

public class TestController : MonoBehaviour
{
    public UIManager uiManager;               // UIManager ����
    public BackgroundRepeat backgroundRepeat; // BackgroundRepeat ����

    void Update()
    {
        if (UIManager.isWaitingForStart) return;

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            uiManager.ReduceLife();
          
        }

      
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.IncreaseLife();
          
        }

    
        if (Input.GetKeyDown(KeyCode.A))
        {
            uiManager.UseLaser();
           
        }

      
        if (Input.GetKeyDown(KeyCode.D))
        {
            uiManager.RechargeLaser();

        }

      
        if (Input.GetKeyDown(KeyCode.K))
        {
            uiManager.DefeatBoss();

        }
    }
}
