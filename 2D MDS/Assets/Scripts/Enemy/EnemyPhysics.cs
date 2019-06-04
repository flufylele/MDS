using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPhysics : MonoBehaviour
{   [SerializeField]
    public float startinglife = 50f;
    private float currentLife;
    [SerializeField]
    private Image healthBar;
    private float value=20;
    


    private void Start()
    {
        currentLife = startinglife;
        healthBar.fillAmount = currentLife / startinglife; // Filling the health bar to maximum
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" )
        {
            if (currentLife>0)
            {
                currentLife -= Weapon.damage; //enemy health - Player's damage
                healthBar.fillAmount = currentLife / startinglife; // Updating the health bar everytime the enemy gets hit by the player
            }
            if(currentLife <=0)
            {
                FindObjectOfType<Audiomanager>().Play("EnemyDeath");
                Destroy(gameObject);
                PlayerMoney.money += value;

            }
        
        }
       

    }

}
