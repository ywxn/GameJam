using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    float timer;
    public GameObject slime;
    private bool isGameStarted = false;
    private float gameStartTime;
    private int score = 0;

    // Control how quickly the game speeds up.
    public float initialSpawnRate = 1.0f;
    public float minSpawnRate = 0.5f;
    public float spawnRateDecreaseRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = initialSpawnRate; // Set the initial spawn rate.
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

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(slime, transform.position, transform.rotation);
            timer = Random.Range(0, 1f) + Mathf.Max(minSpawnRate, initialSpawnRate - spawnRateDecreaseRate * score) + 0.3f;
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
    }
}