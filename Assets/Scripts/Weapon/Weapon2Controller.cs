using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Controller : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}
