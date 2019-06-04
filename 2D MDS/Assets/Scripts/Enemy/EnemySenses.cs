using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySenses : MonoBehaviour
{

    public float speed;
    public float startingDistance;
    public Transform firePoint; // The place where the bullet will be instantiated from
    public GameObject bulletPrefab;
    public bool facingRight = true;
    float fireRate;

    [SerializeField]
    private float nextFire;

    private Transform target;
    public static bool enable = true; // variable used in the game manager when you die. this gets set to false so the enemies will stop shooting while you are dead






    private void Start()
    {
        enable = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireRate = 1f;
        nextFire = Time.time;
    }

    private void Update()
    {
         if(enable == true)
        {
            if (Vector2.Distance(transform.position, target.position) < startingDistance) // if the player is in the enemy's radius
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // move towards the player

                if (transform.position.x < target.position.x && facingRight == false) // Flip depending on the player's orientation (left or right)
                {
                    Flip();
                }
                if (transform.position.x > target.position.x && facingRight == true)
                {
                    Flip();
                }

                Shoot();
            }
        }

        


    }

    void Shoot()
    {   
        if(Time.time > nextFire) // Shooting interval
        {   
            if(facingRight == true) // The fireball prefab is only drawn from left to right so when the enemy is facing right it is ok to just instantiate it
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }
            else // When he is facing left the fireball prefab has to be flipped
            {
                GameObject newObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Vector3 scale = newObject.transform.localScale;
                scale.x *= -1;
                newObject.transform.localScale = scale;
            }
           
            nextFire = Time.time + fireRate;
        }
        
    }


    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }


}

