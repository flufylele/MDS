using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPhysics : MonoBehaviour
{
    [SerializeField] public float startinglife = 1000f;
    private float currentLife;
    [SerializeField] private Image healthBar;
    private float value = 500;
    public GameManager Game_Manager;



    private void Start()
    {
        currentLife = startinglife;
        healthBar.fillAmount = currentLife / startinglife; // Filling the health bar to maximum
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (currentLife > 0)
            {
                currentLife -= Weapon.damage; //Bosshealth - Player's damage
                healthBar.fillAmount = currentLife / startinglife; // Updating the health bar everytime the boss gets hit by the player

                if (currentLife <= 0)
                {
                    FindObjectOfType<Audiomanager>().Play("EnemyDeath");
                    FindObjectOfType<Audiomanager>().StopAll();
                    FindObjectOfType<Audiomanager>().Play("BossTheme");
                    Destroy(gameObject);
                    PlayerMoney.money += value; // Killing the boss gives the player money
                    //Game_Manager.CompleteLevel(); // When there will be a 2nd chapter this will continue go to the shop after killing the boss but for now it gets you to credits (next line)
                    Game_Manager.Credits();


                }

            }

        }


    }

}
