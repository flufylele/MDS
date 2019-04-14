using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static float money = 5000;
    private CoinPickUpDestroy coin;
    [SerializeField]
    private Text ui;

    private void Start()
    {
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinPickUpDestroy>();
    }

    private void Update()
    {
        ui.text = "Coins: " + money.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            money += coin.value;
        }
    }

}
