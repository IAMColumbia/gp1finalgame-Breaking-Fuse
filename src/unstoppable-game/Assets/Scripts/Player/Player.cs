using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public Vector2 Direction;
    public float Speed;
    public GameObject guardBarrier;

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
        gameObject.transform.position = new Vector2(0, -2f);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.IsKeyDown) this.Direction = playerController.direction;
        else
        {
            this.Direction = Vector3.zero;
        }

        UpdateGuardBarrier();
        
    }

    void FixedUpdate()
    { 
        rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    

    private void UpdateGuardBarrier()
    {
        if (!GameManager.playerHit)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                guardBarrier.transform.rotation = Quaternion.Euler(0f, 0f, 60f);
                guardBarrier.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                guardBarrier.transform.rotation = Quaternion.Euler(0f, 0f, -60f);
                guardBarrier.SetActive(true);
            }
            else
            {
                guardBarrier.SetActive(false);
            }
        }
        
    }

}
