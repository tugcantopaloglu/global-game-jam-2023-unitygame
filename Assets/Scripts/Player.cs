using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public GameObject towerPrefab; // The prefab for the tower to be spawned
    private BoxCollider2D towerCollider;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       
        UpdateMotor(new Vector3(x, y, 0));
        
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the spacebar is pressed
        {
            SpawnTower(); // Spawn the tower
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            this.xSpeed = 2f;
            Debug.Log("pressed");
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

    void Run()
    {
        this.xSpeed = 5f;
    }
}
