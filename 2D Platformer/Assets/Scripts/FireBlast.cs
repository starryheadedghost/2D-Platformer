using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public float speed;

    public int damage = 1;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed; //add velocity make object go
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);     
        }
        Destroy(gameObject); //goodbye fireball
    }

}
