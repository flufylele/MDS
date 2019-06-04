using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Shop UI
public class UI : MonoBehaviour
{
    [SerializeField] private Text currentMoney;
    [SerializeField] private Text currentFireRate;
    [SerializeField] private Text currentDamage;
    [SerializeField] private Text currentHealth;
    private float fireRatePrice = 100f;
    private float damagePrice = 120f;
    private float healthPrice = 75f;


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
        if(PlayerMoney.money >= fireRatePrice && Weapon.fireRate >= 0.09)
        {
            Weapon.fireRate -= 0.05f;
            PlayerMoney.money -= fireRatePrice;
            currentFireRate.text = Weapon.fireRate.ToString();
        }

        else if (PlayerMoney.money >= fireRatePrice && Weapon.fireRate > 0.04 && Weapon.fireRate <0.08) // Last upgrade
        {
            currentFireRate.text = "MAX";
        }
    
    }

    public void upgradeDamage()
    {
        if(PlayerMoney.money > damagePrice)
        {
            Weapon.damage += 15;
            PlayerMoney.money -= damagePrice;
        }
    }

    public void upgradeHealth()
    {
        if(PlayerMoney.money > healthPrice)
        {
            PlayerLife.startingLife += 20;
            PlayerMoney.money -= healthPrice;
        }
    }

    public void continueGame()
    {
        SceneManager.LoadScene(GameManager.lastSceneIndex + 1);
    }
      

}
