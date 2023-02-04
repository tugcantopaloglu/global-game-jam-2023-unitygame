using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform target; // The enemy target
    [SerializeField] float range = 15f; // The range of the tower
    [SerializeField] float fireRate = 1f; // The fire rate of the tower
    [SerializeField] int damage = 50; // The damage dealt by the tower

    private float fireCountdown = 1f; // The countdown until the tower can fire again

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // Find a new target every 0.5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) // If there is no target
        {
            return;
        }

        if (fireCountdown <= 0f) // If the tower is ready to fire
        {
            Shoot();
            fireCountdown = 1f / fireRate; // Reset the fire countdown
        }

        fireCountdown -= Time.deltaTime; // Decrement the fire countdown
    }

    // Find a new target
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all the enemies
        float shortestDistance = Mathf.Infinity; // The shortest distance to an enemy
        GameObject nearestEnemy = null; // The nearest enemy

        foreach (GameObject enemy in enemies) // For each enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // The distance to the enemy
            if (distanceToEnemy < shortestDistance) // If this enemy is closer than the current closest enemy
            {
                shortestDistance = distanceToEnemy; // Update the shortest distance
                nearestEnemy = enemy; // Update the nearest enemy
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) // If there is a target in range
        {
            target = nearestEnemy.transform; // Set the target
        }
        else
        {
            target = null; // Clear the target
        }
    }

    // Shoot at the target
    void Shoot()
    {
        Damage dmg = new Damage
        {
            damageAmount = damage,
            origin = transform.position,
            pushForce = 2f
        };
        // Do damage to the target
        target.SendMessage("ReceiveDamage", dmg);
        Debug.Log("hit"+ dmg);
    }

    // Draw the tower's range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
