using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed;
    public GameObject bulletprefab;
    public Transform firePoint;

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
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

        Destroy(bullet, 4.0f);


    }

}
