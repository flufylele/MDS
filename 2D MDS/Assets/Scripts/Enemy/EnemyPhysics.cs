using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    public float life = 100f;
    public Weapon arma;
    


    private void Start()
    {
        arma = GameObject.FindGameObjectWithTag("PlayerGun").GetComponent<Weapon>();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (life>0)
            {
                life -= arma.damage;
            }
             else
        {
            Destroy(gameObject);
        }
        
        }
       

    }

}
