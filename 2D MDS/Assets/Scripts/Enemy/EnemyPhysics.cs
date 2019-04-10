using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPhysics : MonoBehaviour
{
    public float startinglife = 100f;
    private float currentLife;
    private Weapon arma;
    [SerializeField]
    private Image healthBar;
    


    private void Start()
    {
        arma = GameObject.FindGameObjectWithTag("PlayerGun").GetComponent<Weapon>();
        currentLife = startinglife;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (currentLife>0)
            {
                currentLife -= arma.damage;
                healthBar.fillAmount = currentLife / startinglife;
            }
            if(currentLife == 0)
            {
                Destroy(gameObject);
            }
        
        }
       

    }

}
