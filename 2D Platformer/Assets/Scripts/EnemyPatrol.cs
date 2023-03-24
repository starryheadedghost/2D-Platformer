using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Enemy Move Info")]
    public float speed; //how fast it moves

    public float rayDistance; //how far the ray extends

    private bool isMovingRight = true; //checks the enemy is moving right

    public Transform groundDetection; //is enemy touching ground

    // Update is called once per frame
    void Update()
    {
        //move enemy right 
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //raycasting 
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if(isMovingRight == true)
            {
                //flip enemy at edge to move left
                transform.eulerAngles = new Vector3(0,-180,0);
                isMovingRight = false;
            }
            else
            {
                {
                    //flip enemy at to move right
                    transform.eulerAngles = new Vector3(0,0,0);
                    isMovingRight = true;
                }
            }
        }
    }

}
