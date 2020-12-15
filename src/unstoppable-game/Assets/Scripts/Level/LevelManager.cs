using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelTile levelTileStarter;
    public LevelTile levelTileLeft;
    public LevelTile levelTileRight;
    public LevelTile levelTileWFullGround;


    private bool hasRandomized = false;

    private void Awake()
    {
        //Scroll Starter Level Tiles
        gameObject.transform.position = new Vector2(0, 0);
        Instantiate(levelTileStarter);
        Instantiate(levelTileStarter, new Vector2(0, 10), Quaternion.identity.normalized);
    }


    public void AddFullGroundTile()
    {
        //Finish up the Intro by adding the first Full Ground level tile
        if (!GameManager.introScrollCompleted) 
        { 
            Instantiate(levelTileWFullGround, new Vector2(0, 10f), Quaternion.identity.normalized);
            GameManager.introScrollCompleted = true;
        }
    }

    public void RandomizeNextTile()
    {
        if (!hasRandomized) 
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                Instantiate(levelTileLeft, new Vector2(0, 20f), Quaternion.identity.normalized);
            }
            else
            {
                Instantiate(levelTileRight, new Vector2(0, 20f), Quaternion.identity.normalized);
            }
            hasRandomized = true;
        }
        else
        {
            hasRandomized = false;
        }
        
    }

}
