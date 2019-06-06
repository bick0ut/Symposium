using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AI : MonoBehaviour
{
    public Transform firePoint;

    private GameObject map;
    private GameObject Player;
    private bool cooldown;

    private float moveSpeed;
    public GameObject creep;
    public GameObject creepV;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.0f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
        if (Player != null)
        {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        if (!cooldown)
        {
            cooldown = true;
            Shoot();
            Invoke("Cooldown", 0.4f);
        }
    }

    void Shoot()
    {
        Instantiate(creep, firePoint.position, firePoint.rotation*Quaternion.Euler(0, 0, Random.Range(0,361)));
    }

    void Cooldown()
    {
        cooldown = false;
    }

    public void Explode()
    {
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 0));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 45));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 135));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 225));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 270));
        Instantiate(creepV, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 315));
    }
}
