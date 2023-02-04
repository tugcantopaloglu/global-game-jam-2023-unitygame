using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float HitPoints;
    public float MaxHitPoints = 5;
    public HealthBarBehavior HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        HitPoints = MaxHitPoints;
        HealthBar.setHealth(HitPoints,MaxHitPoints);
    }

    public void TakeHit(float damage)
    {
        HitPoints -= damage;
        HealthBar.setHealth(HitPoints, MaxHitPoints);

        if (HitPoints < 0)
        {
            Destroy(gameObject);
        }
    }
    
}
