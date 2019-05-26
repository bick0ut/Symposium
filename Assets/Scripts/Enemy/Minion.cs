﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private GameObject map;

    public float damage;
    public float health;

    private bool alive = true;

    private void Start()
    {
        map = GameObject.FindWithTag("Map");
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

            Destroy(gameObject);
        }
    }
}