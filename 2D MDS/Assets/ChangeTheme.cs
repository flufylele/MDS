using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTheme : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Audiomanager>().Stop("Chapter1Theme");
        FindObjectOfType<Audiomanager>().Play("BossTheme");
    }
 
}
