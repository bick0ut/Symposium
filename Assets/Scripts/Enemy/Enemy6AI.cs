using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6AI : MonoBehaviour
{
    public Animator shoot;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private GameObject map;
    private GameObject Player;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        if (!cooldown)
        {
            cooldown = true;
            shoot.Play("Enemy8Animation", 0, 0);
            Invoke("Shoot", 0.5f);
            Invoke("Cooldown", 2f);
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
