using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public CountdownTimer countdownTimer;
    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void Training()
    {
        SceneManager.LoadScene(1);
    }

    public void Test()
    {
        SceneManager.LoadScene(2);
    }

    public void Guide()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Debug.Log("QUIT!");       
        //Application.Quit();
    }

    public void OnMainMenuButtonClick()
    {
        countdownTimer.ReturnToMainMenu();
    }

    

    
 
    





}
