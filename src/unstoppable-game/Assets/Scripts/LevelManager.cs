using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Awake()
    {
        gameObject.transform.position = new Vector2(0, 0);
    }
}
