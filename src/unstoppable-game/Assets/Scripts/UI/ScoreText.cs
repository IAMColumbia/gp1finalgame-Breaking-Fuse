using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : StatText
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        statText.text = "Score: " + ScoreManager.Score.ToString();
    }
}
