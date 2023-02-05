using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform dayTarget; // The enemy target
    [SerializeField] float range = 15f; // The range of the tower
    [SerializeField] float fireRate = 1f; // The fire rate of the tower
    [SerializeField] int damage = 50; // The damage dealt by the tower
    [SerializeField] Transform nightTarget;
    [SerializeField] GameObject projectilePrefab;
    private float fireCountdown = 1f; // The countdown until the tower can fire again
    private CountDownTimer timer = new CountDownTimer();
    Animator animator;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // Find a new target every 0.5 seconds
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.GetCycle() == "day")
        {
            fireRate = 1.5f;
            damage = 20;
        }
        else if (timer.GetCycle() == "night")
        {
            fireRate = 2f;
            damage = 15;
        }

        if (dayTarget == null && nightTarget == null) // If there is no target
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (timer.GetCycle() == "day")
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all the enemies
        }
        else if(timer.GetCycle() == "night")
        {
            enemies = GameObject.FindGameObjectsWithTag("Player"); // Find all the enemies
        }

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
            if (timer.GetCycle() == "day")
            {
                dayTarget = nearestEnemy.transform; // Set the target
            }
            else if (timer.GetCycle() == "night")
            {
                nightTarget = nearestEnemy.transform; // Set the target
            }

        }
        else
        {
            dayTarget = null; // Clear the target
            nightTarget = null;
        }
    }

    // Shoot at the target
    void Shoot()
    {
        animator.SetTrigger("activTrigger");
        Projectile projectile = new Projectile();

        Damage dmg = new Damage
        {
            damageAmount = damage,
            origin = transform.position,
            pushForce = 2f
        };
        // Do damage to the target
        if (timer.GetCycle() == "day")
        {
            dayTarget.SendMessage("ReceiveDamage", dmg);
            projectile.SetTarget(dayTarget);
        }
        else if (timer.GetCycle() == "night")
        {
            nightTarget.SendMessage("ReceiveDamage", dmg);
            projectile.SetTarget(nightTarget);
        }
        
    }

    // Draw the tower's range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
