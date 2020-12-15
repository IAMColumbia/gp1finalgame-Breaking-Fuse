using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiates instances of a given Coin object prefab
/// </summary>
public class CoinManager : MonoBehaviour
{
    public Coin coin_prefab;
    Coin[] coins = new Coin[4];

    private void Start()
    {
        SpawnCoins(gameObject);
    }

    private void SpawnCoins(GameObject tile)
    {
        coins[0] = Instantiate(coin_prefab, new Vector2(GetRandCoinX(), tile.transform.position.y + 3), Quaternion.identity);
        coins[1] = Instantiate(coin_prefab, new Vector2(GetRandCoinX(), tile.transform.position.y + 1), Quaternion.identity);
        coins[2] = Instantiate(coin_prefab, new Vector2(GetRandCoinX(), tile.transform.position.y + -1), Quaternion.identity);
        coins[3] = Instantiate(coin_prefab, new Vector2(GetRandCoinX(), tile.transform.position.y + -3), Quaternion.identity);

        foreach (Coin c in coins)
        {
            c.transform.SetParent(tile.transform);
        }
    }

    public void RespawnCoins()
    {
        SpawnCoins(gameObject);
    }

    float GetRandCoinX()
    {
        float coinX = 0f;
        int rand = Random.Range(0, 2);
        if (rand == 0) coinX = -1.5f;
        else if (rand == 1) coinX = 1.5f;
        return coinX;
    }

}
