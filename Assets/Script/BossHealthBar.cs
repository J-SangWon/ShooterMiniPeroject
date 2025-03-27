using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image fillImage;
    private float currentHealth;
    private float maxHealth = 100f;
    public bool IsDead => currentHealth <= 0f;

    
    public void InitBar()
    {
        currentHealth = maxHealth;
        UpdateFill();
        gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        UpdateFill();
    }

    public void HideBar()
    {
        gameObject.SetActive(false);
    }

    public void ResetBar()
    {
        currentHealth = maxHealth;
        UpdateFill();
        gameObject.SetActive(false);
    }

    private void UpdateFill()
    {
        float fillAmount = currentHealth / maxHealth;
        fillImage.fillAmount = fillAmount;
    }
}
