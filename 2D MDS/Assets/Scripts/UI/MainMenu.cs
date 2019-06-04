using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level_1");
        FindObjectOfType<Audiomanager>().StopAll();
        FindObjectOfType<Audiomanager>().Play("Chapter1Theme");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
