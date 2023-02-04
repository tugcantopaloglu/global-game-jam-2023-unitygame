using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;
    public float spawnRadius = 5.0f;
    public float maxEnemies = 6;
    public float minDistance = 4.0f;

    private float spawnTimer = 0.0f;

    private void Update()
    {
        maxEnemies += Time.deltaTime/15;
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer = 0.0f;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(randomPos.x, randomPos.y, 0);

        // Check if there's another enemy too close
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos, minDistance);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                return;
            }
        }

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.tag = "Enemy";

        // Add a move towards the player component
        EnemyMovement enemyMovement = enemy.AddComponent<EnemyMovement>();
        enemyMovement.target = GameObject.FindWithTag("Player").transform;
    }
}
