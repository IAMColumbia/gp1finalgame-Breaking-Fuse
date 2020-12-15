using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    TMPro.TextMeshProUGUI infoText;

    // Start is called before the first frame update
    void Start()
    {
        infoText = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(TeachPlayer());
    }

    private void Update()
    {
        if (GameManager.playerHit) ShowFinalScore();
    }

    IEnumerator TeachPlayer()
    {
        infoText.text = "Welcome to Unstoppable";
        yield return new WaitForSeconds(3);
        infoText.text = "Use A/D to Move Left/Right";
        yield return new WaitForSeconds(3);
        infoText.text = "Use Left/Right Arrow Keys to Guard";
        yield return new WaitForSeconds(3);
        infoText.text = "Collect Coins, Successfully Guard, and Survive to get points!" +
            "\nAvoid projectiles and falling off!";
        yield return new WaitForSeconds(5);
        infoText.text = "Get Ready...";
        yield return new WaitForSeconds(2);
        infoText.text = "";

    }

    void ShowFinalScore()
    {
        if (GameManager.highscoreUpdated)
        {
            infoText.text = $"The New Highscore is { ScoreManager.Highscore } with a Time of { ScoreManager.Highscore_Time} seconds!";
        }
        else 
        {
            infoText.text = $"Your Score was {ScoreManager.Score} with a Time of {GameManager.ElapsedTime} seconds.";
        }
        infoText.text += "\nPress Tab to try again!";
    }

}
