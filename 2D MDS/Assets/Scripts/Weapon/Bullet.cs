using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;


    void Start()
    {
        
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
        FindObjectOfType<Audiomanager>().Play("Shot");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hit" || collision.tag == "Platform" || collision.tag == "Enemy")
        {
            FindObjectOfType<Audiomanager>().Play("ShotImpact");
            Destroy(gameObject);
        }
        
    }


}
