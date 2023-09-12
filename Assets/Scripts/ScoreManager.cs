using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    private bool isGameStarted = false;
    private float gameStartTime;
    private static int score = 0;
    public Text scoreText;
    public HighScoreManager highScoreManager;
    private int highscore;
    private string filePath = "C:/Users/jeanne/OneDrive - Whitman College/Documents/Git/GameJam/Assets/Misc/high_score.txt";

    // Start is called before the first frame update
    void Start()
    {
        // Initialize any variables or UI elements here
        scoreText.text = "Score: " + score;
        highscore = Int32.Parse(File.ReadAllText(filePath));
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            UpdateScore();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        gameStartTime = Time.time;
    }

    void UpdateScore()
    {
        // Calculate the score based on the time played
        score = Mathf.FloorToInt(Time.time - gameStartTime);

        // Update the score text
        scoreText.text = "Score: " + score;
    }
    public static int GetScore()
    {
        return score;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void SetGameStarted(bool gameover)
    {
        isGameStarted = gameover;
    }

    public int GetHighScore()
    {
        return highscore;
    }

}
