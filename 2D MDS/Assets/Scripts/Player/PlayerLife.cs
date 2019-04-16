using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    public static float startingLife=100;
    private float currentLife;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthNumber;
    private WeaponEnemy armaInamic;
    public GameObject deathSceneUI;
    
 

    private void Start()
    {
        armaInamic = GameObject.FindGameObjectWithTag("Enemy").GetComponent<WeaponEnemy>();
        currentLife = startingLife;
    }

    private void Update()
    {
        healthNumber.text = currentLife.ToString() + " / " + startingLife.ToString();

        if (transform.position.y < -5)
        {
            FindObjectOfType<GameManager>().GameOver();
            deathSceneUI.SetActive(true);
            FindObjectOfType<Audiomanager>().Stop("Chapter1Theme");
            FindObjectOfType<Audiomanager>().Play("Death");
            Vector3 temp = new Vector3(0, 1000000000000f, 0);
            transform.position += temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletEnemy")
        {
            if (currentLife > 0)
            {
                currentLife -= armaInamic.damage;
                healthBar.fillAmount = currentLife / startingLife;
                if (currentLife <= 0)
                {
                    FindObjectOfType<GameManager>().GameOver();
                    deathSceneUI.SetActive(true);
                    FindObjectOfType<Audiomanager>().Stop("Chapter1Theme");
                    FindObjectOfType<Audiomanager>().Stop("BossTheme");
                    FindObjectOfType<Audiomanager>().Play("Death");

                }
            }


        }


    }


}
