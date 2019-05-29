using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public GameObject CreepPrefab;
    public GameObject WallPrefab;

    public Transform firePoint;

    private bool cooldown;
    private bool ecooldown;

    // Start is called before the first frame update
    void Start()
    {
        ecooldown = false;
        cooldown = false;
        moveSpeed = 1.25f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);

        if (!cooldown)
        {
            cooldown = true;
            Attack();
            Invoke("Cooldown", 3.5f);
        }
    }

    void Attack()
    {
        Invoke("Shoot", 0.5f);
    }

    void Shoot()
    {
        Instantiate(WallPrefab, firePoint.position, firePoint.rotation);
    }

    void Cooldown()
    {
        cooldown = false;
    }

    void Ecooldown()
    {
        ecooldown = false;
    }

    public void Explode()
    {
        if (!ecooldown)
        {
            ecooldown = true;
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 0));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 45));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 135));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 180));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 225));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 270));
            Instantiate(CreepPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 315));
            Invoke("Ecooldown", 0.5f);
        }
    }

}
