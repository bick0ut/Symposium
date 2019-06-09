using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8AI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject WarningPrefab;
    public Transform firePoint;

    private GameObject map;
    private GameObject Player;
    private bool cooldown;
    private bool teleporting;
    private bool tcooldown;
    private Vector3 tppos;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = true;
        tcooldown = true;
        Invoke("TCooldown", Random.Range(5, 11));
        Invoke("Cooldown", Random.Range(0, 2));
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();

        float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            return;
        }

        if (!tcooldown)
        {
            tcooldown = true;
            Teleport();
        }

        if (!cooldown && !teleporting)
        {
            cooldown = true;
            Shoot();
            Invoke("Cooldown", 3f);
        }
    }

    void Shoot()
    {
        float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        AngleDeg += Random.Range(-6, 7);
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Teleport()
    {
        teleporting = true;
        int xRange = Random.Range(-10, 10);
        int yRange = Random.Range(-3, 4);
        tppos = new Vector3(xRange, yRange, 0);
        Instantiate(WarningPrefab, tppos, Quaternion.identity);
        Invoke("TP", 0.6f);
    }

    void TP()
    {
        transform.position = tppos;
        teleporting = false;
        Invoke("TCooldown", Random.Range(5, 11));
    }

    void TCooldown()
    {
        tcooldown = false;
    }

    void Cooldown()
    {
        cooldown = false;
    }
}
