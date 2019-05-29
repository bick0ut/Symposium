using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public Animator walk;
    public GameObject JavelinPrefab;
    public GameObject NetPrefab;

    public Transform firePoint;

    private bool cooldown;
    private bool walking;
    private bool alt;

    // Start is called before the first frame update
    void Start()
    {
        alt = true;
        moveSpeed = 1.5f;
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

        if (!cooldown)
        {
            walking = false;
            walk.enabled = false;
            cooldown = true;
            Attack();
            Invoke("Cooldown", 4f);
        }
    }

    void Attack()
    {
        alt = !alt;
        if (alt)
        {
            Invoke("Shoot", 0.2f);
            Invoke("Shoot", 0.4f);
            Invoke("Shoot", 0.6f);
            Invoke("Shoot", 0.8f);
            Invoke("Shoot", 1.0f);
            Invoke("Shoot", 1.2f);
            Invoke("Shoot", 1.4f);
            Invoke("Shoot", 1.6f);
            Invoke("Shoot", 1.8f);
            Invoke("Shoot", 2.0f);
            Invoke("WideShoot", 2.2f);
            Invoke("Walk", 2.2f);
        }
        else
        {
            Instantiate(NetPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-15, 16)));
            Invoke("Walk", 1.0f);
        }
    }

    void Shoot()
    {
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation);
    }

    void WideShoot()
    {
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-32,-27)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-17,-12)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation);
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(13,18)));
        Instantiate(JavelinPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(28,33)));
    }

    void Walk()
    {
        walking = true;
        walk.enabled = true;
    }
    void Cooldown()
    {
        cooldown = false;
    }

}
