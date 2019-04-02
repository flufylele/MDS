using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private float life;

    private WeaponEnemy armaInamic;

    private void Start()
    {
        armaInamic = GameObject.FindGameObjectWithTag("EnemyGun").GetComponent<WeaponEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletEnemy")
        {
            if (life > 0)
            {
                life -= armaInamic.damage;
                Debug.Log(life);
            }
            else
            {
                FindObjectOfType<GameManager>().GameOver();
            }

        }


    }
}
