using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public int maxHealth = 20;
    private int health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
