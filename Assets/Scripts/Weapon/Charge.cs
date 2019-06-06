using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
        }

        Minion minion = collision.GetComponent<Minion>();

        if (minion != null)
        {
            minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
        }


        Boss boss = collision.GetComponent<Boss>();

        if (boss!= null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
        }
        
        if(collision.tag == "Mask")
        {
            collision.transform.parent.GetComponent<Enemy5AI>().Speed();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        this.transform.position = player.transform.position;
        if (player.GetComponent<PlayerController>().IsCharging() == false)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
    }
}
