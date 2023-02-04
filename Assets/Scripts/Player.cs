using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 10 && x != -3.6 && y != 3.6 && y != -3.6)
        {
            UpdateMotor(new Vector3(x, y, 0));
        }
    }
}
