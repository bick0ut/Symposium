using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public GameObject SwordPrefab;
    public GameObject WarningPrefab;

    public Transform firePoint;

    private bool acooldown;
    private bool walking;
    private Vector3 playerPos;

    public AudioSource teleportSound;

    private Boss boss;
    private float rage;

    // Start is called before the first frame update
    void Start()
    {
        acooldown = true;
        Invoke("ACooldown", 4f);
        moveSpeed = 1.25f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
        walking = true;
        boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        rage = 1.5f - (boss.GetHealth() / boss.GetMaxHealth());
        if (Player != null) {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        if (walking)
        {
            transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
        }

        if (!acooldown)
        {
            acooldown = true;
            walking = false;
            Attack();
            Invoke("ACooldown", 8.25f - (5*rage));
        }
    }

    void Attack()
    {
        playerPos = Player.transform.position;
        int rand = Random.Range(0, 8);
        if (rand == 0)
        {
            playerPos += new Vector3(0, 2f);
        } else if (rand == 1)
        {
            playerPos += new Vector3(1.5f, 1.5f);
        } else if (rand == 2)
        {
            playerPos += new Vector3(2f, 0);
        } else if (rand == 3)
        {
            playerPos += new Vector3(1.5f, -1.5f);
        } else if (rand == 4)
        {
            playerPos += new Vector3(0, -2f);
        } else if (rand == 5)
        {
            playerPos += new Vector3(-1.5f, -1.5f);
        } else if (rand == 6)
        {
            playerPos += new Vector3(-2f, 0);
        } else
        {
            playerPos += new Vector3(-1.5f, 1.5f);
        }
        Instantiate(WarningPrefab, playerPos, Quaternion.identity);

        Invoke("Shoot", 0.5f);
        Invoke("Walk", 1.0f);
    }

    void Shoot()
    {
        transform.position = playerPos;
        teleportSound.Play(0);
        Instantiate(SwordPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -90));
    }

    void Walk()
    {
        walking = true;
    }

    void ACooldown()
    {
        acooldown = false;
    }
}
