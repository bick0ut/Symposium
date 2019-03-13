using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject map;

    private int health = 10;
    private int damage = 1;

    private void Start()
    {
        map = GameObject.FindWithTag("Map");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public int getDamage()
    {
        return damage;
    }
    void Die()
    {
        map.GetComponent<MapController>().EnemyKilled();
        Destroy(gameObject);
    }
}
