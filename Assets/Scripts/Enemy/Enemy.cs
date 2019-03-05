using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 10;
    private int damage = 1;

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
        Destroy(gameObject);
    }
}
