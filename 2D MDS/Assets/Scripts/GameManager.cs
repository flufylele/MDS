using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public PlayerPhysics script;
    public float restartDelay = 2f;


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            script.enabled = false;
            Invoke("Restart", restartDelay);
        }




    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        Invoke("Restart", restartDelay);
    }


}
