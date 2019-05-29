using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Sword : MonoBehaviour
{
    private GameObject map;
    public float damage;
    private GameObject player;
    private GameObject boss;
    Vector3 point;
    private int tick;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map");
        damage *= (1 + (int)(0.5 * (map.GetComponent<MapController>().GetFloor() / 5)));
        boss = GameObject.FindWithTag("Boss");
        point = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, 0);
        tick = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boss != null)
        {
            this.transform.position = boss.transform.position;
        } else { 
            Destroy(gameObject);
        }

        if (tick > 20)
        {
            Destroy(gameObject);
        }
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), 9);
        tick++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable())
            { 
                player.TakeDamage(damage);
            }
        }

    }
}
