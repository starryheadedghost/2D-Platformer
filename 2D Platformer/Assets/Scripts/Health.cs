using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ui library 

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public int numberOfhearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


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
        if(currentHealth > numberOfhearts)
        {
            currentHealth = numberOfhearts;
        }
        for( int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numberOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
