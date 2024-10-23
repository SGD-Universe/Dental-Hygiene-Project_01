using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour, IGameTimer
{
    public float totalTime = 600f; // Total time for the countdown timer
    private float currentTime; // Current time left in the countdown timer
    public TextMeshProUGUI timerText; // Reference to the UI text component to display the timer
    private bool allTargetsReached = false; // Flag to track if all draggable objects are in their target locations
    [SerializeField] float remainingTime;
    public GameObject gameOverPanel; // Reference to the game over panel

    void Start()
    {
        currentTime = totalTime; // Initialize the current time to the total time
        StartTimer(); // Start the countdown timer
    }

    void Update()
    {
        remainingTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the time as an integer
    }

    void StartTimer()
    {
        InvokeRepeating("UpdateTimer", 1f, 1f); // Invoke the UpdateTimer method every second
    }

    void UpdateTimer()
    {
        if (!allTargetsReached)
        {
            currentTime -= 1; // Decrement the current time
        }
        if (currentTime <= 0f)
        {
            CancelInvoke("UpdateTimer"); // Stop the countdown timer
            GameOver(); // Call the game over method when the time runs out
        }
    }

    public void AllTargetsReached()
    {
        allTargetsReached = true; // Set the flag to true when all targets are reached
        GameOver(); // Call the game over method when all targets are reached
    }

    public void GameOver()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Show the game over panel
        gameOverPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game time scale is reset
        // Load the main menu scene (you can adjust the scene index as needed)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f; // Ensure the game time scale is reset
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
