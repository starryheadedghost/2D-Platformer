using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(health <= 0)
         {
            Destroy(gameObject);
            Debug.Log("nice");
         }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage; //damage is taken out of health 
        Debug.Log(damage + "ow");
    }

    
}
