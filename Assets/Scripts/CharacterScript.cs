using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    /*
    
    Factory Pattern:

        Character Script uses inheritance to propogate common functions down to
    child scripts. Both the player and the enemies can move and can die. So why
    program these functions multiple times when you can create a common parent
    script that shares these functions between objects.

    */

    Rigidbody2D body;

    public float health;
    public float speed;

    public virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // both the player and the enemies use the move function.
    public void Move(Vector2 dir)
    {
        body.velocity = dir.normalized * speed;
    }

    public void TakeDamage(float dam)
    {
        // take damage
        health -= dam;
        
        // if health is less than 0, die.
        if (health < 0)
        {
            Die();
        }
    }

    // 'virtual' methods are one's child scripts can alter later using an 'override'
    public virtual void Die()
    {
        // destroy self
        Destroy(this);
    }
}
