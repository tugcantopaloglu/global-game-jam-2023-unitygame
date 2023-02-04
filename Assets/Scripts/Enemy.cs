using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    //Logic
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    public HealthBar healthBar;


    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        hitpoint = maxHitpoint;
        healthBar.setMaxHealth(hitpoint);
        base.Start();
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        healthBar.setHealth(hitpoint);
    }

    private void FixedUpdate()
    {
        
        //Collision work
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }
            //The array is not cleaned up, so we do it ourself
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        //GameManager.instance.experience += xpValue;
        //GameManager.instance.ShowText("+" + xpValue, 64, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }

}
