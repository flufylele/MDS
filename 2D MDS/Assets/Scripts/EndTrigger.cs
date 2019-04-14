
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager Game_Manager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Game_Manager.CompleteLevel();
        }
        
    }

}
