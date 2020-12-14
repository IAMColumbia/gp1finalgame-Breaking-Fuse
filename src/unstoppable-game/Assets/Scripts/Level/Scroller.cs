using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public LevelManager levelManager;

    public BoxCollider2D col;

    public Rigidbody2D rb;

    private float height;

    private float scrollSpeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = col.size.y;
        col.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -height)
        {
            levelManager.RandomizeNextTile();
            Destroy(gameObject);
        }

    }
}
