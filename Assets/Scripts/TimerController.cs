using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float totalTime = 600f; // Total time for the countdown timer
    private float currentTime; // Current time left in the countdown timer

    public TextMeshProUGUI timerText; // Reference to the UI text component to display the timer

    private bool allTargetsReached = false; // Flag to track if all draggable objects are in their target locations
    [SerializeField] float remainingTime;



    void Update()
    {

        remainingTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the time as an integer
    }

    void Start()
    {
        currentTime = totalTime; // Initialize the current time to the total time
        StartTimer(); // Start the countdown timer
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
            // Game over, handle accordingly (e.g., display game-over screen, reset level)
            CancelInvoke("UpdateTimer"); // Stop the countdown timer
        }

    }

    public void AllTargetsReached()
    {
        allTargetsReached = true; // Set the flag to true when all targets are reached
    }
}
