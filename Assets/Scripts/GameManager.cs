using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameObject enemyPrefab;

    // we will use a queue to store our enemies
    Queue<EnemyController> enemies = new Queue<EnemyController>();

    float t = 0;
    public float spawnRate = 0;

    private void Update()
    {
        // spawn rate of 0 means no enemeis spawn
        if (spawnRate > 0)
        {
            // over time enemies will spawn
            t += Time.deltaTime * spawnRate;

            // after t is greater than 10, spawn an enemy
            if (t >= 10)
            {
                t = 0;

                // get pos of player, add a random offset so they don't spawn on the player
                Vector2 pos = player.transform.position;
                pos += Random.insideUnitCircle.normalized * 5;
                SpawnEnemy(pos);
            }
        }
    }

    /*
     
    Object Pooling:

        The destroy enemy function keeps enemies that have died in an object pool and then spawn enemies
    available in the pool to save resources. If an enemy is not available, then it will instantiate a new
    enemy.
     
    */

    public void DestroyEnemy(EnemyController obj)
    {
        enemies.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void SpawnEnemy(Vector2 pos)
    {
        // try peak will try to get the first item in enemy queue. If null will retun false
        if (enemies.TryPeek(out EnemyController obj))
        {
            // get enemy from queue and enable it.
            obj.gameObject.SetActive(true);
            obj.transform.position = pos;

            obj.health = enemyPrefab.GetComponent<EnemyController>().health;
            enemies.Dequeue();
        }
        else 
        { 
            // if no enemy available, create a new one from scratch.
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = pos;
        }
    }
}
