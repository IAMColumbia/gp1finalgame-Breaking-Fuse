using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject levelTile;

    private void Start()
    {
        levelTile = GetComponent<GameObject>();
    }
    void Awake()
    {
        gameObject.transform.position = new Vector2(0, 0);
        Instantiate(levelTile);
        Instantiate(levelTile, new Vector2(0, 10), Quaternion.identity.normalized);
    }
}
