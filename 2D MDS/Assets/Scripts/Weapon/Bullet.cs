using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb; // Bullet's rigidbody

    void Start()
    {
        rb.velocity = transform.right * speed; // Making the bullet travel
        Destroy(gameObject, 3f); // Destroying it after 3 seconds so it doesn't start making the game lag when there are too many instances of bullets
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
