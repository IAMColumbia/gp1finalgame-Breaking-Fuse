using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        value = 1;
    }

    private void Update()
    {
        //Do not allow this to live past the player
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Score += value;
            Destroy(gameObject);
        }
    }
}
