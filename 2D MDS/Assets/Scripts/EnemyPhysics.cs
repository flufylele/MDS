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
        if(life>0)
        {
            if (collision.tag == "Bullet")
            {
                life -= arma.damage;
                Debug.Log(life);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

}
