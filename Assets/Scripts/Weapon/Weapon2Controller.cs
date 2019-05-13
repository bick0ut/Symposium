using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Controller : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    private PlayerController pc;
    // Update is called once per frame
    private void Awake()
    {
        pc = gameObject.GetComponent<PlayerController>();
    }
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
