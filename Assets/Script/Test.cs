using UnityEngine;

public class BossDamageTester : MonoBehaviour
{
    public UIManager uiManager; // UIManager�� �ν����Ϳ��� �Ҵ�

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (uiManager != null)
            {
                uiManager.DamageBoss(10f);
                Debug.Log("�׽�Ʈ: �������� 10 ������");
            }
        }
    }
}
