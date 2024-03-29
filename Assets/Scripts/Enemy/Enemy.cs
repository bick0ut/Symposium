﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthPrefab;
    private MapController map;
    private PlayerController pc;
    private GUI gui;

    public GameObject goldPrefab;

    public float damage;
    public float health;

    private bool alive = true;
    private int bonus;

    private void Start()
    {
        map = GameObject.FindWithTag("Map").GetComponent<MapController>();
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gui = GameObject.FindWithTag("GUI").GetComponent<GUI>();
        health *= (1 + (map.GetComponent<MapController>().GetFloor() / 5) );
        damage *= (1 + (0.5f * (map.GetComponent<MapController>().GetFloor() / 5) ) );
        bonus = map.GetComponent<MapController>().GetFloor();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    void Die()
    {
        if (alive)
        {
            Enemy3AI enemy3 = gameObject.GetComponent<Enemy3AI>();

            if (enemy3 != null)
            {
                enemy3.Explode();
            }

            alive = false;
            if (Random.Range(0, 10) == 0)
            {
                Instantiate(healthPrefab, gameObject.transform.position, Quaternion.identity);
            }

            if (Random.Range(1, 101) + bonus > 90)
            {
                Instantiate(goldPrefab, gameObject.transform.position, Quaternion.identity);
            }

            map.EnemyKilled();
            pc.AddKill();
            if (gui.IsDisplaying()){
                gui.StatsDisplay(pc.GetMaxHealth(), pc.GetMaxEnergy(), pc.GetDamage(), pc.GetKills());
                gui.StatsDisplay(pc.GetMaxHealth(), pc.GetMaxEnergy(), pc.GetDamage(), pc.GetKills());
            }
            Destroy(gameObject);
        }
    }
}
