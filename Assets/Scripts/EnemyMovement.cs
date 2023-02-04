using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        speed = Random.Range(1f, 3f);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
