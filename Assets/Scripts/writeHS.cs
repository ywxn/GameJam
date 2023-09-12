using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class writeHS : MonoBehaviour
{
    public TMP_Text hs;

    private string filePath = "C:/Users/jeanne/OneDrive - Whitman College/Documents/Git/GameJam/Assets/Misc/high_score.txt";
    private int highScore;
    private string bestPlayer;
    private string filePathPlayer = "C:/Users/jeanne/OneDrive - Whitman College/Documents/Git/GameJam/Assets/Misc/hs_player.txt";
    // Start is called before the first frame update
    void Start()
    {
        highScore = Int32.Parse(File.ReadAllText(filePath));
        bestPlayer = File.ReadAllText(filePathPlayer).Replace("\n","").Replace("\r","");
        hs.text = "High Score:\n" + bestPlayer + ": " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
