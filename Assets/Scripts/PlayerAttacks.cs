using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed;
    public GameObject bulletprefab;
    public Transform firePoint;
    public Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot ()
    {      
        var bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        //bullet.transform.position = firePoint.position; 
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

        anim.SetTrigger("Attack");


        Destroy(bullet, 4.0f);
    }

}
