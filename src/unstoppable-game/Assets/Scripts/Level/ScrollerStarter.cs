using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerStarter : MonoBehaviour
{
    public LevelManager levelManager;

    public BoxCollider2D col;

    public Rigidbody2D rb;

    private float height;

    private float scrollSpeed = -2f;

    [SerializeField] private int repeatCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = col.size.y;
        col.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
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
