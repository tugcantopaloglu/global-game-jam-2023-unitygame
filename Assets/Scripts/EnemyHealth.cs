using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        
    }

    public void TakeDamage()
    {
        Debug.Log("Player 1 hit aldı");
        currentHealth--;
        if (currentHealth <= 0)
        {
            // Enemy is dead, handle destruction of the enemy
            Destroy(gameObject);
        }
    }
}