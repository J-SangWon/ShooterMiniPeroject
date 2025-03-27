using UnityEngine;

public class BossDamageTester : MonoBehaviour
{
    public UIManager uiManager; // UIManager를 인스펙터에서 할당

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (uiManager != null)
            {
                uiManager.DamageBoss(10f);
                Debug.Log("테스트: 보스에게 10 데미지");
            }
        }
    }
}
