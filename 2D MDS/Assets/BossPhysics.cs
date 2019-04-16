using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPhysics : MonoBehaviour
{
    [SerializeField]
    public float startinglife = 50f;
    private float currentLife;
    [SerializeField]
    private Image healthBar;
    private float value = 500;
    public GameManager Game_Manager;



    private void Start()
    {
        currentLife = startinglife;
        healthBar.fillAmount = currentLife / startinglife;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (currentLife > 0)
            {
                Debug.Log(Weapon.damage);
                currentLife -= Weapon.damage;
                healthBar.fillAmount = currentLife / startinglife;

                if (currentLife <= 0)
                {
                    FindObjectOfType<Audiomanager>().Play("EnemyDeath");
                    FindObjectOfType<Audiomanager>().Stop("BossTheme");
                    FindObjectOfType<Audiomanager>().Play("Chapter1Theme");
                    Destroy(gameObject);
                    PlayerMoney.money += value;
                    Game_Manager.CompleteLevel();


                }

            }

        }


    }

}
