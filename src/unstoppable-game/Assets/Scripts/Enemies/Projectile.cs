using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float moveSpeed = 5f;

    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.playerHit = true;
            Destroy(gameObject);
        }
        else if(collision.transform.name == "GuardBarrier")
        {
            ScoreManager.Score++; //bonus score for blocking a projectile
            Destroy(gameObject);
        }
    }
}
