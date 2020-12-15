using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile_Starter : LevelTile
{
    [SerializeField] private int repeatCounter = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {

        //Repeat/reposition this level tile until counter reaches 0
        if (transform.position.y < -height && repeatCounter > 0)
        {
            repeatCounter--;
            Vector2 resetPosition = new Vector2(0, height * 2f);
            transform.position = (Vector2)transform.position + resetPosition;
        }

        //Repeats are over, destroy next time instead of resetting. Tell GameManager the intro is complete
        if (repeatCounter <= 0)
        {
            if (transform.position.y < -height)
            {
                levelManager.AddFullGroundTile();
                levelManager.RandomizeNextTile();
                Destroy(gameObject);
            }
        }
    }
}
