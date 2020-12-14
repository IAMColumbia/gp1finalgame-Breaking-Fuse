using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public Vector2 Direction;
    public float Speed;

    private Vector3 moveTranslation;
    private Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;

    void Awake()
    {
        Util.GetComponentIfNull<SpriteRenderer>(this, ref spriteRenderer);
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<PlayerController>();
        }
        gameObject.transform.position = new Vector2(0, -1.25f);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.IsKeyDown) this.Direction = playerController.direction;
        else
        {
            this.Direction = Vector3.zero;
        }
    }

    void FixedUpdate()
    { 
        rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Player touched Obstacle!");
            Application.Quit();
        }
    }
}
