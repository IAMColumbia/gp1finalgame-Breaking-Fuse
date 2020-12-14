using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Vector2 direction = new Vector2();
    public Vector2 keyDirection;
    public bool IsKeyDown
    {
        get
        {
            if (keyDirection.sqrMagnitude == 0) return false;
            return true;
        }
    }

    public PlayerController()
    {

    }

    void Awake()
    {
        keyDirection = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {

        //direction.x = direction.y = 0;
        keyDirection.x = keyDirection.y = 0;

        //Keyboard
        if (Input.GetKey(KeyCode.D))
        {
            keyDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            keyDirection.x += -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            keyDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            keyDirection.y += -1;
        }

        direction += keyDirection;
        direction.Normalize();

    }
}
