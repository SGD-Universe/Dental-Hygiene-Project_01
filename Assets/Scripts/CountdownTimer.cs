using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the UI text component to display the timer
    public float totalTime = 600f; // Total time for the countdown timer (10 minutes)
    private float currentTime; // Current time left in the countdown timer
    [SerializeField] float remainingTime;
    private bool isPaused = false; // Flag to track if the game is paused

    

    void Start()
    {
        currentTime = totalTime; // Initialize the current time to the total time
        UpdateTimerText(); // Update the UI text initially
        StartTimer(); // Start the countdown timer
    }

    void Update()
    {
        //ensures that the countdown timer accurately reflects the passage of time, decrements at a consistent rate.
        remainingTime -= Time.deltaTime;
        //calculates the number of minutes remaining in the countdown timer.
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the time as an integer

        if (!isPaused && currentTime <= 0f)
        {
            PauseGame(); // Pause the game when the timer reaches 10 minutes
        }
    }

    void UpdateTimerText()
    {
        timerText.text = FormatTime(currentTime); // Display the time formatted as MM:SS
    }

    string FormatTime(float timeInSeconds)
    {
        //calculates the number of minutes remaining in the countdown timer.
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StartTimer()
    {
        InvokeRepeating("UpdateTimer", 1f, 1f); // Invoke the UpdateTimer method every second
    }

    void UpdateTimer()
    {
        if (!isPaused)
        {
            currentTime -= 1f; // Decrement the current time
            UpdateTimerText(); // Update the UI text
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        isPaused = true;

        // Display main menu button
        // Assuming you have a GameObject named mainMenuButton that contains the main menu button
        GameObject mainMenuButton = GameObject.Find("MainMenuButton");

        if (mainMenuButton != null)
        {
            mainMenuButton.SetActive(true);
        }

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
