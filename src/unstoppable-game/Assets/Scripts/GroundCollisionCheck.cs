using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name + " entered trigger!");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.name + " left trigger!");
    }
}
