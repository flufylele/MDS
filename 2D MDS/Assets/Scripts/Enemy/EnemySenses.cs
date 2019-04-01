using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySenses : MonoBehaviour
{

    public float speed;
    public float startingDistance;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool facingRight = true;
    float fireRate;

    [SerializeField]
    private float nextFire;

    private Transform target;




    private Animator anim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireRate = 1f;
        nextFire = Time.time;
        anim= GetComponent<Animator>();
    }

    private void Update()
    {
         

        if(Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position.x < target.position.x && facingRight == false)
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

    void Shoot()
    {   
        if(Time.time > nextFire)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
        
    }


    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }


}

