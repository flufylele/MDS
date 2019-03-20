using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float life = 100;
    public WeaponEnemy armaInamic;

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsVariable;
    private Animator anim;


    private Rigidbody2D rb;
    private SpriteRenderer sr;


    void Start()
    {
        armaInamic = GameObject.FindGameObjectWithTag("EnemyGun").GetComponent<WeaponEnemy>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

    }


    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsVariable;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletEnemy")
        {
            if (life > 0)
            {
                life -= armaInamic.damage;
                Debug.Log(life);
            }
            else
            {
                FindObjectOfType<GameManager>().GameOver();
            }

        }


    }

}
