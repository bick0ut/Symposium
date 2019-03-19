using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3Controller : MonoBehaviour
{
    public Transform firePoint;
    public GameObject swordPrefab;

    private bool cooldown;
    private int tick;

    // Update is called once per frame
    void Update()
    {
        if (tick > 20)
        {
            Cooldown();
        } else
        {
            tick++;
        }

        if (Input.GetMouseButton(0) && !cooldown)
        {
            Attack();
            tick = 0;
            cooldown = true;
        }
    }

    void Attack()
    {
        Instantiate(swordPrefab, firePoint.position, firePoint.rotation*Quaternion.Euler(0,0,-90));
    }

    void Cooldown()
    {
        cooldown = false;
    }
}
