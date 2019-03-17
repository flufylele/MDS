using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySenses : MonoBehaviour
{

    public float speed;
    public float startingDistance;
    public Transform firePoint;
    public GameObject bulletPrefab;
    float fireRate;
    float nextFire;

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


}

