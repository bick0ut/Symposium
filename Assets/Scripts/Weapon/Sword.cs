using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private GameObject player;
    Vector3 point;
    private int tick;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        point = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, 0);
        tick = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            this.transform.position = player.transform.position;
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
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*3);
        }

        Minion minion = collision.GetComponent<Minion>();

        if (minion != null)
        {
            minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*3);
        }

        Boss boss = collision.GetComponent<Boss>();

        if (boss != null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*3);
        }

        if(collision.tag == "Mask")
        {
            Destroy(gameObject);
        }
    }
}
