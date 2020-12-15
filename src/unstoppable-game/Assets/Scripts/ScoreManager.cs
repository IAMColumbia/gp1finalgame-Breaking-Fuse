public class ScoreManager
{
    private static int score = 0;
    private static int highscore = 0;
    private static int highscore_time = 0;

    public static int Score { get => score; set => score = value; }
    public static int Highscore { get => highscore; set => highscore = value; }
    public static int Highscore_Time { get => highscore_time; set => highscore_time = value; }

    public static void UpdateHighscore()
    {
        //Highscore has a value
        if (Highscore != 0)
        {
            if (Score > Highscore)
            {
                SetNewHighscore();
            }
        }
        //Highscore not yet initialized
        else
        {
            SetNewHighscore();
        }
    }

    private static void SetNewHighscore()
    {
        Highscore = Score;
        Highscore_Time = GameManager.ElapsedTime;
        GameManager.highscoreUpdated = true;
    }

    public static void Reset()
    {
        Score = 0;
    }

}
