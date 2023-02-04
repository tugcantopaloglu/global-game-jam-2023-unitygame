using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                // Player is dead, handle game over
            }

            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage();
        }
    }
}