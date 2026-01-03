using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    public int maxHealth = 20;
    private int health;

    [Header("UI")]
    public Image healthFill; // yeþil bar

    void Start()
    {
        health = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
            Die();
    }

    void UpdateHealthBar()
    {
        healthFill.fillAmount = (float)health / maxHealth;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
