using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //reset time back to real time 
        currentHealth = maxHealth;// start with max health
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Ow = " + currentHealth);

        if(currentHealth <=0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0; //freeze game
        }
    }
    
    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
