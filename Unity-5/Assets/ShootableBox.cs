using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootableBox : MonoBehaviour
{

    //The box's current health point total
    public int currentHealth = 3;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            GameObject enemyImage = GameObject.Find(gameObject.name + "Enemy");
            enemyImage.SetActive(false);
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive(false);
            CountOfLightsCust.countEnemies++;
        }
    }
}