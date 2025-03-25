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
          
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            uiManager.ReduceLife_P2();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            uiManager.IncreaseLife();
          
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            uiManager.IncreaseLife_P2();

        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            uiManager.UseLaser();
           
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            uiManager.UseLaser_P2();

        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            uiManager.RechargeLaser();

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            uiManager.RechargeLaser_P2();

        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            uiManager.DefeatBoss();

        }
    }
}
