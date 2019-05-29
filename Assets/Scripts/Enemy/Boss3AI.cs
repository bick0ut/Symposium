using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public GameObject SwordPrefab;
    public GameObject WallPrefab;

    public Transform firePoint;

    private bool acooldown;
    private bool bcooldown;
    private bool walking;
    private bool attacking;
    private bool blocking;
    private Vector3 original;

    // Start is called before the first frame update
    void Start()
    {
        acooldown = false;
        bcooldown = false;
        moveSpeed = 1.0f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
        walking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        if (walking)
        {
            transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
        }

        if (!acooldown && !blocking)
        {
            acooldown = true;
            walking = false;
            Attack();
            Invoke("ACooldown", 6f);
        }
    }

    void Attack()
    {
        original = transform.position;
        Vector3 playerPos = Player.transform.position - (Player.transform.forward * 5 );
        transform.position = playerPos;
        Invoke("Shoot", 0.5f);
        Invoke("Reset", 1.0f);
        Invoke("Walk", 1.0f);
    }

    private void Reset()
    {
        transform.position = original;
    }
    void Shoot()
    {
        Instantiate(SwordPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -90));
    }

    void Block()
    {
        Instantiate(WallPrefab, firePoint.position, firePoint.rotation);
    }

    void Walk()
    {
        walking = true;
    }

    void ACooldown()
    {
        acooldown = false;
    }

    void Bcooldown()
    {
        bcooldown = false;
    }

}
