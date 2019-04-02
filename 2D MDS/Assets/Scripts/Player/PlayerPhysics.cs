using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPhysics : MonoBehaviour
{
    private float moveInput;
    private bool facingRight = true;
    private Animator anim;
    private Rigidbody2D rb;



    [Header("Character move forces")]
    [SerializeField]
    private float speed=20;
    [SerializeField]
    private float jumpForce=40;

    [Header("Ground check")]
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool extraJump;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        extraJump = true;
    }

    void FixedUpdate()
    {
        

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

  
    }


    void Update()
    {
        

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded==true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("IsJumping", true);
            isGrounded = false;

        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded == false && extraJump == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump = false;

        }


        moveInput = Input.GetAxisRaw("Horizontal");

        if (transform.position.y < -13)
        {
            FindObjectOfType<GameManager>().GameOver();
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            extraJump = true;
            anim.SetBool("IsJumping", false);
        }
    }




    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }




}
