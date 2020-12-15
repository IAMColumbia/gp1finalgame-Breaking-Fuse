using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool introScrollCompleted = false;
    public static bool playerHit = false;
    public static bool highscoreUpdated = false;
    public LevelManager levelManager;
    public Player player;

    private static int elapsedTime; //increments from timeSinceLevelLoad

    public static int ElapsedTime { get => elapsedTime; set => elapsedTime = value; }

    private void Start()
    {
        elapsedTime = Mathf.FloorToInt(Time.deltaTime);
    }

    // Update is called once per frame
    private void Update()
    {
        elapsedTime = Mathf.FloorToInt((Time.timeSinceLevelLoad));

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        CheckForPlayerHit();
    }

    /// <summary>
    /// Pause and Wait to Replay the game
    /// </summary>
    private void CheckForPlayerHit()
    {
        if (playerHit)
        {
            Time.timeScale = 0;
            ScoreManager.UpdateHighscore();
            //Wait for Player to press TAB to Replay
            if (Input.GetKey(KeyCode.Tab)) ResetGame();
        }
    }

    /// <summary>
    /// Reset Values, Cleanup/Reinstantiate Level Manager and Player objects
    /// </summary>
    private void ResetGame()
    {
        ScoreManager.Reset();
        playerHit = false;
        introScrollCompleted = false;
        highscoreUpdated = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


}
