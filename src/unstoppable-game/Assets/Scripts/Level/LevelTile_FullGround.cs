using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile_FullGround : LevelTile
{

    CoinManager coinManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coinManager = GetComponent<CoinManager>();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        if (transform.position.y < -height)
        {
            coinManager.RespawnCoins();
            Vector2 resetPosition = new Vector2(0, height * 2f);
            transform.position = (Vector2)transform.position + resetPosition;
            levelManager.RandomizeNextTile();
        }

    }
}
