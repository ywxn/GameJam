using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    private int highScore;
    private string highScorePlayer;
    private int currentScore;
    private string filePath = "C:/Users/jeanne/OneDrive - Whitman College/Documents/Git/GameJam/Assets/Misc/high_score.txt";
    private string filePath_player = "C:/Users/jeanne/OneDrive - Whitman College/Documents/Git/GameJam/Assets/Misc/hs_player.txt";
    public Text textInput;
        
    void Start()
    {
        LoadHS();
    }
    private void SaveHS()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(currentScore);
        }

    }
    private void LoadHS()
    {
        highScore = Int32.Parse(File.ReadAllText(filePath));
        highScorePlayer = File.ReadAllText(filePath_player);
    }
    void Update()
    {
        currentScore = ScoreManager.GetScore();
        if (currentScore > highScore)
        {
            SaveHS();
        }
    }
    public void SubmitHS()
    {
        highScorePlayer = textInput.text; 
        using (StreamWriter writer = new StreamWriter(filePath_player))
        {
            writer.WriteLine(highScorePlayer);
        }
        SceneManager.LoadScene("Title");
    }
}