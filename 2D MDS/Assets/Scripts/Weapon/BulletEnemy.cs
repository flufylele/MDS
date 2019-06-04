using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb; // Bullet's rigidbody
    public Transform target; 
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveDirection = (target.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        FindObjectOfType<Audiomanager>().Play("Fireball");
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Platform")
        {
            FindObjectOfType<Audiomanager>().Play("FireballExplosion");
            Destroy(gameObject);
        }

    }
}
