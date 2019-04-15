using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<Audiomanager>().Stop("Death");
        FindObjectOfType<Audiomanager>().Play("IntroTheme");


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<Audiomanager>().Play("Chapter1Theme");
        FindObjectOfType<Audiomanager>().Stop("Death"); 
    }
}
