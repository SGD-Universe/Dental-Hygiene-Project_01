using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    public void Quit()
    {
        Debug.Log("QUIT!");       
        //Application.Quit();
    }

    

    
 
    





}
