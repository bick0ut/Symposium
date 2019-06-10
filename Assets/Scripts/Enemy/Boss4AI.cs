using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public Animator walk;
    public GameObject SwordPrefab;
    public GameObject WarningPrefab;
    public GameObject NetPrefab;
    public GameObject JavelinPrefab;
    public GameObject CreepPrefab;
    public GameObject laserPrefab;

    public Transform firePoint;

    private bool acooldown;
    private bool walking;
    private Vector3 playerPos;

    public AudioSource teleportSound;

    private Boss boss;
    private float rage;

    private bool alt;
    private bool jcooldown;
    private bool ecooldown;
    private bool lcooldown;
    private bool attacking;

    private bool lalt;
    // Start is called before the first frame update
    void Start()
    {
        acooldown = true;
        Invoke("ACooldown", Random.Range(5f, 11f));
        jcooldown = true;
        Invoke("JCooldown", Random.Range(3f, 7f));
        lcooldown = true;
        Invoke("LCooldown", 5f);
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

        if(!lcooldown)
        {
            lcooldown = true;
            LaserAttack();
            Invoke("LCooldown", 10f);
        }

        if (!acooldown && !attacking)
        {
            attacking = true;
            acooldown = true;
            walking = false;
            Attack();
            Invoke("ACooldown", 10f - (4*rage));
        }

        if (!jcooldown && !attacking)
        {
            attacking = true;
            jcooldown = true;
            WideJavelin();
            Invoke("JCooldown", 4f);
        }
    }
    IEnumerator LaserTimer(float y)
    {
        yield return new WaitForSeconds(2f+(y/5f));
        Laser(y);
    }

    void LaserAttack()
    {
        lalt = !lalt;
        if (lalt)
        {
            for (float i = 10; i <= -6; i -= 0.5f)
            {
                StartCoroutine(LaserTimer(i));
            }
        } else
        {
            for (float i = -10; i <= 6; i += 0.5f)
            {
                StartCoroutine(LaserTimer(i));
            }
        }
    }

    void Laser(float y)
    {
        Instantiate(laserPrefab, new Vector3(0, y, 0), Quaternion.identity);
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

        Invoke("Shoot", 0.6f);
        Invoke("Walk", 1.0f);
    }

    void LCooldown()
    {
        lcooldown = false;
    }

    void Shoot()
    {
        transform.position = playerPos;
        teleportSound.Play(0);
        Instantiate(SwordPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -90));
    }

    void ACooldown()
    {
        acooldown = false;
    }

    void WideJavelin()
    {
        alt = !alt;
        if (alt)
        {
            Invoke("Javelin", 0.2f);
            Invoke("Javelin", 0.4f);
            Invoke("Javelin", 0.6f);
            Invoke("Javelin", 0.8f);
            Invoke("Javelin", 1.0f);
            Invoke("Javelin", 1.2f);
            Invoke("Javelin", 1.4f);
            Invoke("Javelin", 1.6f);
            Invoke("Javelin", 1.8f);
            Invoke("Javelin", 2.0f);
            Invoke("WideShoot", 2.2f);
        }
        else
        {
            Instantiate(NetPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-15, 16)));
            Invoke("Walk", 1.0f);
        }
    }

    void Javelin()
    {
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation);
    }

    void WideShoot()
    {
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-32, -27)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-17, -12)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation);
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(13, 18)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(28, 33)));
        attacking = false;
    }

    void Walk()
    {
        walking = true;
        walk.enabled = true;
        attacking = false;
    }

    void JCooldown()
    {
        jcooldown = false;
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
