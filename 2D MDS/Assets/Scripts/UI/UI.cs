using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text currentMoney;
    [SerializeField]
    private Text currentFireRate;
    [SerializeField]
    private Text currentDamage;
    [SerializeField]
    private Text currentHealth;


    private void Start()
    {
        currentMoney.text = "Current money: " + PlayerMoney.money.ToString();
        currentDamage.text = Weapon.damage.ToString();
        currentFireRate.text = Weapon.fireRate.ToString();
        currentHealth.text = PlayerLife.startingLife.ToString();
    }

    void Update()
    {
        currentMoney.text = "Current money: " + PlayerMoney.money.ToString();
        currentDamage.text = Weapon.damage.ToString();
        
        currentHealth.text = PlayerLife.startingLife.ToString();
    }


    public void upgradeFireRate()
    {
        if(PlayerMoney.money > 50 && Weapon.fireRate > 0.05)
        {
            Weapon.fireRate -= 0.05f;
            PlayerMoney.money -= 50;
            currentFireRate.text = Weapon.fireRate.ToString();
        }

        else
        {
            currentFireRate.text = "MAX";
        }
    
    }

    public void upgradeDamage()
    {
        if(PlayerMoney.money > 35)
        {
            Weapon.damage += 15;
            PlayerMoney.money -= 35;
        }
    }

    public void upgradeHealth()
    {
        if(PlayerMoney.money > 35)
        {
            PlayerLife.startingLife += 20;
            PlayerMoney.money -= 35;
        }
    }

    public void continueGame()
    {
        SceneManager.LoadScene(GameManager.lastSceneIndex + 1);
    }
      

}
