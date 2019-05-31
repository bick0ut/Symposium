﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlast : MonoBehaviour
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
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*0.1f);
        }

        Minion minion = collision.GetComponent<Minion>();

        if (minion != null)
        {
            minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*0.1f);
        }


        Boss boss = collision.GetComponent<Boss>();

        if (boss!= null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*0.3f);
        }
        
        if(collision.tag == "Mask")
        {
            collision.transform.parent.GetComponent<Enemy5AI>().Speed();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mouse;

        if (!Input.GetMouseButton(1)||Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3))
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
        player.GetComponent<PlayerController>().LoseEnergy(2.0f);
        if (player.GetComponent<PlayerController>().GetEnergy() == 0)
        {
            Destroy(gameObject);
        }
    }
}
