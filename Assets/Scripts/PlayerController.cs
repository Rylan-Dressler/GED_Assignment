using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;



public class PlayerController : CharacterScript
{
    private void Update()
    {
        Vector2 dir = Vector2.zero;

        // Input
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }

        // Defined in CharacterScript
        Move(dir);
    }
}
