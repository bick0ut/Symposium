using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1Controller : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool cooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&!cooldown)
        {
            Shoot();
            cooldown = true;
            Invoke("Cooldown", 0.2f);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Cooldown()
    {
        cooldown = false;
    }
}
