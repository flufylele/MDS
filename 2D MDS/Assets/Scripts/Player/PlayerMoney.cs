using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static float money = 0;
    private CoinPickUpDestroy coin; // Script where the coin's value is
    [SerializeField]
    private Text ui; // Top left ui text

    private void Start()
    {
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinPickUpDestroy>();
    }

    private void Update()
    {
        ui.text = "Coins: " + money.ToString();
    }

    // Picking up coins
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            money += coin.value;
        }
    }

}
