using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private float startingLife=100;
    private float currentLife;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthNumber;
    private WeaponEnemy armaInamic;
 

    private void Start()
    {
        armaInamic = GameObject.FindGameObjectWithTag("Enemy").GetComponent<WeaponEnemy>();
        currentLife = startingLife;
    }

    private void Update()
    {
        healthNumber.text = currentLife.ToString() + " / " + startingLife.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletEnemy")
        {
            if (currentLife > 0)
            {
                currentLife -= armaInamic.damage;
                healthBar.fillAmount = currentLife / startingLife;
            }
            if(currentLife == 0)
            {
                FindObjectOfType<GameManager>().GameOver();
            }

        }


    }


}
