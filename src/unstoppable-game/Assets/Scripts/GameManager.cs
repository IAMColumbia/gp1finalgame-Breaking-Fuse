using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool introScrollCompleted = false;

    private int score;

    public int Score { get => score; set => score = value; }


    // Update is called once per frame
    void Update()
    {
        Score = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        Debug.Log(Score); // score
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
