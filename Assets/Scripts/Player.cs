using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public GameObject towerPrefab; // The prefab for the tower to be spawned
    private BoxCollider2D towerCollider;
    private CountDownTimer timer = new CountDownTimer();
    [SerializeField] float towerPrice = 500f;
    public HealthBar healthBar;


    private void FixedUpdate()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       
        UpdateMotor(new Vector3(x, y, 0));


        
    }
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitpoint);
        healthBar.setHealth(hitpoint);
        if (Input.GetKeyDown(KeyCode.Space) && timer.GetScore()>=towerPrice) // If the spacebar is pressed
        {
            timer.DeletePointFromScore(towerPrice);
            SpawnTower(); // Spawn the tower
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            xSpeed = 8f;
            ySpeed = 8f;
            spriteRenderer.color = new Color(0.514151f, 1f, 0.9759827f);
        }
        else
        {
            xSpeed = 5f;
            ySpeed = 5f;
            spriteRenderer.color = new Color(1, 1, 1);
        }
    }

    // Spawn a tower and activate its collider after 3 seconds
    void SpawnTower()
    {
        GameObject tower = Instantiate(towerPrefab, transform.position, transform.rotation); // Spawn the tower
        towerCollider = tower.GetComponent<BoxCollider2D>(); // Get the collider component of the tower

        Invoke("ActivateTowerCollider", 3f); // Activate the collider after 3 seconds
    }

    // Activate the tower collider
    void ActivateTowerCollider()
    {
        towerCollider.enabled = true; // Enable the collider
    }
}
