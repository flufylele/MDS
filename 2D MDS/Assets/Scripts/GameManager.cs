using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public PlayerPhysics script;
    public Weapon script2;
    public float restartDelay = 2f;
    public static int lastSceneIndex;


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            script.enabled = false;
            script2.enabled = false;
            EnemySenses.enable = false;
        }




    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Shop");
    }

  

}
