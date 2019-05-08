using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AI : MonoBehaviour
{
    public Transform firePoint;

    private GameObject map;
    private GameObject Player;
    private bool cooldown;

    public GameObject creep;

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
            Invoke("Shoot", 1.0f);
            Invoke("Cooldown", 1f);
        }
    }

    void Shoot()
    {
        Instantiate(creep, firePoint.position, firePoint.rotation);
    }

    void Cooldown()
    {
        cooldown = false;
    }
}
