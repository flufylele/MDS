using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<Audiomanager>().Stop("IntroTheme");
        FindObjectOfType<Audiomanager>().Play("Chapter1Theme");
    }

    public void quitGame()
    {
        Application.Quit();
    }


}
