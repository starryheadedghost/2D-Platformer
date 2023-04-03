using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay;
    public float startDelay;
    public Transform attackPos;

    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if(attackDelay <= 0)
        {
            if(Input.GetKey(KeyCode.F))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for(int g=0; g < enemiesToDamage.Length; g++)
                {
                    enemiesToDamage[g].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            attackDelay = startDelay;
        }
            else
            {
                    attackDelay -= Time.deltaTime; //count/cool down
            }
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos. DrawWireSphere(attackPos.position, attackRange);
        }
    }

//why does unity hate me 