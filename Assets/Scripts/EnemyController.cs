using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterScript
{
    Transform player;
    GameManager gameManager;

    // Start is called before the first frame update
    public override void Start()
    {
        // base start required to play the Start() of Character Script.
        base.Start();

        // gets the game manager, then the player from the manager
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // gets the direction of the player and moves towards the player
        Vector2 dir = player.position - transform.position;
        Move(dir);
    }

    // 'override' 
    public override void Die()
    {
        // 'base' will play the base functon. (we don't want to destroy enemies)
        //base.Die();

        // we will use object pooling function in the game manager instead.
        gameManager.DestroyEnemy(this);
    }
}
