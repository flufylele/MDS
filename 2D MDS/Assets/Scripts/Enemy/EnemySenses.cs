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






    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireRate = 1f;
        nextFire = Time.time;
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
            if(facingRight == true)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }
            else
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

