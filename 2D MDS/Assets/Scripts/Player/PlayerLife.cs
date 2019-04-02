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
    private WeaponEnemy armaInamic;
 

    private void Start()
    {
        armaInamic = GameObject.FindGameObjectWithTag("Enemy").GetComponent<WeaponEnemy>();
        currentLife = startingLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletEnemy")
        {
            if (currentLife > 0.01)
            {
                currentLife -= armaInamic.damage;
                healthBar.fillAmount = currentLife / startingLife;
            }
            else
            {
                FindObjectOfType<GameManager>().GameOver();
            }

        }


    }


}
