using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private bool active = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                canvas.SetActive(false);
            }

    }
}
