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
    [SerializeField]
    private int extraJumpsVariable;
    private int extraJumps;


    [Header("Character move forces")]
    [SerializeField]
    private float speed=20;
    [SerializeField]
    private float jumpForce=40;

    [Header("Ground check")]
    public Transform groundCheck;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

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
        if (isGrounded == true)
        {
            anim.SetBool("IsJumping", false);
            extraJumps = extraJumpsVariable;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            anim.SetBool("IsJumping", true);
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("IsJumping", true);
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (transform.position.y < -13)
        {
            FindObjectOfType<GameManager>().GameOver();
        }


    }


    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }





}
