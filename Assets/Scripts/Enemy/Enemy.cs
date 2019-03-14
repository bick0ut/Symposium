using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject map;

    private float health = 10;
    private float damage = 1;

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

    public float getDamage()
    {
        return damage;
    }
    void Die()
    {
        map.GetComponent<MapController>().EnemyKilled();
        Destroy(gameObject);
    }
}
