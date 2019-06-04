using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script used on a coin in the boss scene (out of view) to change the normal theme in the boss theme. The coin is there just for this script to use so do not remove it!
public class ChangeTheme : MonoBehaviour
{

    private void Start()
    {
        FindObjectOfType<Audiomanager>().StopAll();
        FindObjectOfType<Audiomanager>().Play("BossTheme");
    }
 
}
