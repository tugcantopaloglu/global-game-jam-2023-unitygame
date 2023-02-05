using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        float speed = 10f;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
