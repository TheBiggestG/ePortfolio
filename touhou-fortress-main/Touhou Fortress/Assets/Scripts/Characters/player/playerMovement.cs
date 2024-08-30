using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;
    public float speed;

    private void FixedUpdate()
    {
        //Inputs for movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Speed modifier (Control)
        float speedMod = 1.0f;

        //Set Movement var and get rigidbody of player.
        var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        var rigidbody = GetComponent<Rigidbody>();

        if (movement.x != 0.0f && movement.z != 0.0f)
        {
            // You could use the reversed pythagorean theorem instead, but it would be superficial.
            movement.x = movement.x * 0.707f;
            movement.z = movement.z * 0.707f;
        }

        if (Input.GetKey(KeyCode.LeftControl) == true) speedMod = 0.5f;


        //Movement set with inputs times the speed membervar.
        rigidbody.velocity = movement * speed * speedMod;

        //Boundaries.
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, zMin, zMax)
        );
    }
}
