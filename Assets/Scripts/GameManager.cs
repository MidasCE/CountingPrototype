using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Counter counter;
    public ProbsSpawnManager spawnManager;
    public GameObject titleGroup;
    public TMP_Text timeText;
    public Button startButton;
    
    public TMP_Text gameOverText;
    public Button restartButton;
    
    public bool isGameActive;

    private const int DefaultGameTime = 60;
    
    private int _gameTime;
    
    public void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        _gameTime = DefaultGameTime;
        isGameActive = true;
        counter.EnableCounter();
        spawnManager.StartSpawning();
        StartCoroutine(TimerCountdown());
        timeText.gameObject.SetActive(true);
        titleGroup.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        spawnManager.StopSpawning();
        StopCoroutine(TimerCountdown());
        counter.DisableCounter();
        isGameActive = false;
        timeText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        spawnManager.DestroyAllChildren();
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartGame();
    }

    IEnumerator TimerCountdown()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            _gameTime -= 1;
            timeText.text = "Time left : " + _gameTime;

            if (_gameTime <= 0)
            {
                gameOverText.text = "TIME UP!";
                GameOver();
            }
        }
    }
}
