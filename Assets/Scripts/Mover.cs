using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 5f;
    protected float xSpeed = 5f;
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = new Vector3(0, 0, 0);

    }

    
    protected virtual void UpdateMotor(Vector3 input)
    {
        if (moveDelta.y != 3.5f && moveDelta.y != -3.5f && moveDelta.x != -10.5f && moveDelta.x != 10.5f)
        {
        //Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

            if (moveDelta.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            moveDelta += pushDirection;

            //Reduce the push force every frame, based off recovery speed
            pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

            //move y
            //Make sure we can move in this direction, by casting a box there first, if the box null, we're free to move
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

            if (hit.collider == null)
            {
                //Move
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }
        }

    }
}
