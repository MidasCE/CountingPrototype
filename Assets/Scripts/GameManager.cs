using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ProbsSpawnManager spawnManager;
    public TMP_Text titleText;
    public Button startButton;
    
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public Button restartButton;
    
    public bool isGameActive;

    public void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        isGameActive = true;
        spawnManager.StartSpawning();
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }


    public void GameOver()
    {
        spawnManager.StopSpawning();
        isGameActive = false;
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
}
