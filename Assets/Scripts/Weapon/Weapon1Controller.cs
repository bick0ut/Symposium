using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1Controller : MonoBehaviour
{
    private GameObject player;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool cooldown = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&!cooldown)
        {
            Shoot();
            cooldown = true;
            Invoke("Cooldown", 1.0f);
        }

        if (Input.GetMouseButton(1) && player.GetComponent<PlayerController>().GetEnergy() >= 100)
        {
            BigShoot();
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

    void BigShoot()
    {
        player.GetComponent<PlayerController>().LoseEnergy(100);
        for(int i = 0; i < 15; i++)
        {
            float x = Random.Range(-45, 46);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, x));
        }
    }
    void Cooldown()
    {
        cooldown = false;
    }

}
