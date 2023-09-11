using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private bool isGameStarted = false;
    private float gameStartTime;
    private int score = 0;
    public Text scoreText;

    // Other variables and functions you may need...

    // Start is called before the first frame update
    void Start()
    {
        // Initialize any variables or UI elements here
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            StartGame();
        }

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
    
    public int GetScore()
    {
        return score;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

}
