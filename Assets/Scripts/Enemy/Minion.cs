using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private GameObject map;
    private GameObject boss;

    public float damage;
    public float health;

    private bool alive = true;

    private void Awake()
    {
        boss = GameObject.FindWithTag("Boss");
        Physics2D.IgnoreCollision(boss.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Start()
    {
        map = GameObject.FindWithTag("Map");
        health *= (1 + (map.GetComponent<MapController>().GetFloor() / 5));
        damage *= (1 + (int)(0.5 * (map.GetComponent<MapController>().GetFloor() / 5)));
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
