using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour,IGameTimer
{
    public TextMeshProUGUI timerText;
    public float totalTime = 600f;
    private float currentTime;
    [SerializeField] float remainingTime;
    private bool isPaused = false;
    public GameObject timesUpMenu;
    public GameObject gameOverPanel; 

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!isPaused)
        {
            currentTime -= Time.deltaTime;
            remainingTime = currentTime;
            UpdateTimerText();
            if (currentTime <= 0f)
            {
                PauseGame();
                timesUpMenu.SetActive(true);
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        GameObject mainMenuButton = GameObject.Find("MainMenuButton");
        if (mainMenuButton != null)
        {
            mainMenuButton.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetTimer()
    {
        currentTime = totalTime;
        remainingTime = totalTime;
        isPaused = false;
        UpdateTimerText();
        timesUpMenu.SetActive(false);
    }

    public void GameOver()
    {
        isPaused = true; // Pause the game
        Time.timeScale = 0f; // Pause the timer
        gameOverPanel.SetActive(true); // Show the game over panel
    }
}

