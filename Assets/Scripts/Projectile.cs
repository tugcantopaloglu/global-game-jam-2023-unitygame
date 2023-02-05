using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Transform projectileTarget;
    private void Update()
    {
        float speed = 10f;
        transform.position = Vector2.MoveTowards(transform.position, projectileTarget.position, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        projectileTarget = target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
