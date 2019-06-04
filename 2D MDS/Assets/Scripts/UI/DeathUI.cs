using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<Audiomanager>().StopAll();
        FindObjectOfType<Audiomanager>().Play("IntroTheme");
    }

    public void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
        FindObjectOfType<Audiomanager>().StopAll();
        FindObjectOfType<Audiomanager>().Play("Chapter1Theme");
        
    }
}
