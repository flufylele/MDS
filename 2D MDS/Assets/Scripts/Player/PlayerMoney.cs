﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private float money = 0;
    private CoinPickUpDestroy coin;


    private void Start()
    {
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinPickUpDestroy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            money += coin.value;
            Debug.Log(money);
        }
    }

}