using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsGameRunning { get; set; } = false;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;
    private float currentTime;

    private void OnEnable()
    {
        GameEvents.GameOverEvent+=OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnGameOver;
    }

    private void OnGameOver()
    {
        IsGameRunning = false;
        DataSaver.SaveCurrentScoreData(score);
        DataSaver.SaveHighestScoreData(score);
    }

    public int Score => score;

    private void Update()
    {
        if(!GameManager.Instance.IsGameRunning)    return;

        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            score += 10;
            scoreText.SetText("Score: "+score);
            currentTime = 0;
        }
    }


}//Class
