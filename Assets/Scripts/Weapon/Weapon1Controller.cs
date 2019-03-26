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
            Invoke("Cooldown", 1.0f);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -30));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -15));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 15));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 30));
    }

    void Cooldown()
    {
        cooldown = false;
    }
}
