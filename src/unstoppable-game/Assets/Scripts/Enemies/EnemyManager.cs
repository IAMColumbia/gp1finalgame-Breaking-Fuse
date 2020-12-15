using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles an enemy's life in a given Level Tile. Currently specific to "WallTurrets".
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnEnemy(gameObject);
    }


    void SpawnEnemy(GameObject tile)
    {
        GameObject newEnemy;
        GameObject newEnemy2;
        float enemyX = GetRandEnemyX();
        float enemyY = GetRandEnemyY();
        newEnemy = Instantiate(enemy, new Vector2(enemyX, enemyY), GetEnemyRotation(enemyX));
        newEnemy2 = Instantiate(enemy, new Vector2(-enemyX, GetEnemyYOpposite(enemyY)), GetEnemyRotation(-enemyX));
        newEnemy.transform.parent = tile.transform;
        newEnemy2.transform.parent = tile.transform;
    }

    /// <summary>
    /// Get a semi-random value to choose which side of a level tile the enemy will be on.
    /// </summary>
    /// <returns>Either -4.5f or 4.5f based on random chance</returns>
    float GetRandEnemyX()
    {
        //-4.5f = left wall of a level tile
        // 4.5f = right wall of a level tile
        float enemyX = 0f;
        int rand = Random.Range(0,2);
        if (rand == 0) enemyX = -4.5f;
        else if (rand == 1) enemyX = 4.5f;
        return enemyX;
    }
    /// <summary>
    /// Get a semi-random value for an enemy's y-position on a level tile.
    /// </summary>
    /// <returns>Either 1.25f and 3.75f based on random chance</returns>
    float GetRandEnemyY()
    {
        //1.25f = middle of second to top section of wall 
        //3.75f = middle of top-most section of wall
        float enemyY = transform.position.y;
        int rand = Random.Range(0, 2);
        if (rand == 0) enemyY += 1.25f;
        else if (rand == 1) enemyY += 3.75f;
        return enemyY;
    }
    float GetEnemyYOpposite(float enemyY)
    {
        if (enemyY == transform.position.y + 1.25f) return enemyY - 1.25f + 3.75f;
        else if (enemyY == transform.position.y + 3.75f) return enemyY - 3.75f + 1.25f;
        return enemyY;
    }

    Quaternion GetEnemyRotation(float enemyX)
    {
        //if enemy is to the left of their level tile
        if (enemyX == -4.5f) return Quaternion.identity; //WallTurret Specific - WallTurret sprite starts aimed to the right
        else if (enemyX == 4.5f) return Quaternion.Euler(0f, 180f, 0f);

        return Quaternion.identity;
    }
}
