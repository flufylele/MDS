﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpDestroy : MonoBehaviour
{
    public float value;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Audiomanager>().Play("CoinPickup");
            Destroy(gameObject);
        }
    }
}
