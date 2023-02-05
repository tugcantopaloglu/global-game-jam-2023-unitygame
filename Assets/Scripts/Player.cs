using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Mover
{
    public GameObject towerPrefab; // The prefab for the tower to be spawned
    private BoxCollider2D towerCollider;
    private CountDownTimer timer = new CountDownTimer();
    [SerializeField] float towerPrice = 500f;
    public HealthBar healthBar;
    public Canvas Endcanvas;
    public Canvas Startcanvas;
    [SerializeField] Animator animator;
    
    
    private void FixedUpdate()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       
        UpdateMotor(new Vector3(x, y, 0));


        
    }
    

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(hitpoint);
        if(hitpoint <= 0)
        {
            EndScene();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Endcanvas.gameObject.SetActive(false);
                RestartGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && timer.GetScore()>=towerPrice) // If the spacebar is pressed
        {
            timer.DeletePointFromScore(towerPrice);
            SpawnTower(); // Spawn the tower
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(timer.GetCycle() == "day")
            {
                xSpeed = 8f;
                ySpeed = 8f;
            }
            else
            {
                xSpeed = 12f;
                ySpeed = 12f;
            }
            spriteRenderer.color = new Color(0.514151f, 1f, 0.9759827f);
        }
        else
        {
            if (timer.GetCycle() == "day")
            {
                xSpeed = 5f;
                ySpeed = 5f;
            }
            else
            {
                xSpeed = 8f;
                ySpeed = 8f;
            }
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

        public void EndScene()
        {
            Time.timeScale = 0;
            Endcanvas.gameObject.SetActive(true);

        }
        public void RestartGame()
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Startcanvas.gameObject.SetActive(true);
    }
    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);
        if (moveDelta.x > 1 || moveDelta.x < -1 || moveDelta.y > 1 || moveDelta.y <-1)
        {
            if (timer.GetCycle()=="day")
            {
                animator.SetBool("dayActivTrigger", true);
            }
            else if (timer.GetCycle() == "night")
            {
                animator.SetBool("nightActivTrigger", true);
            }

        }
        else
        {
            if (timer.GetCycle() == "day")
            {
                animator.SetBool("dayActivTrigger", false);
                animator.SetBool("isDay", true);
            }
            else if (timer.GetCycle() == "night")
            {
                animator.SetBool("nightActivTrigger", false);
                animator.SetBool("isDay", false);
            }

        }
    }
}
