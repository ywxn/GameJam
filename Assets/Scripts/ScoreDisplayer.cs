using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplayer : MonoBehaviour
{
    Text score;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "You got the highscore!\n" +
            "Your score: " + ScoreManager.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
