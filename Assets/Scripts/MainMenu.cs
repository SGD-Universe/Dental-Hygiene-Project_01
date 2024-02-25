using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public CountdownTimer countdownTimer;
    //this method allows you to navigate back to the homescreen
    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    //this method allows you to navigate back to the learn screen
    public void Training()
    {
        SceneManager.LoadScene(1);
    }

    //this method allows you to navigate back to the practice screen
    public void Test()
    {
        SceneManager.LoadScene(2);
    }

    //this method allows you to navigate back to the guide screen
    public void Guide()
    {
        SceneManager.LoadScene(3);
    }

    //this method allows you to quit the application
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
