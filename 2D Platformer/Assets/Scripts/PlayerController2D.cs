using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Player Stats")]

    public float speed; //gotta go fast

    public float jumpForce; //jumpy boy

    private float moveInput; //get move input value 

    //player rigidbody
    [Header("Rigidbody")]
    private Rigidbody2D rb;

    private bool isFacingRight = true;

    //player jump!
    [Header("Player Jump Settings")]
    private bool isGrounded = true;

    public Transform groundCheck;

    public float checkRadius;

    public LayerMask whatIsGround;

    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody componant wowow
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //define what is ground

        moveInput = Input.GetAxis("Horizontal"); //get horizontal key binding 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //move player left and right 

        //if player is moving right but facing left, move player right
        if(!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }

        //if player is moving left but faving right flip the player left
        else if(isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; // local variable that stores localscale value
        scaler.x *= -1; //flip sprite graphic
        transform.localScale = scaler;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            doubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce; //make player jump
            doubleJump = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce; //apply jumpforce to player make player jump 
        }
    }
}
