using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour
{
    private GameObject map;
    private GameObject gui;

    public GameObject goldPrefab;

    public float damage;
    public float health;
    public float maxHealth;

    private bool alive = true;

    private void Start()
    {
        map = GameObject.FindWithTag("Map");

        maxHealth *= (1 + (map.GetComponent<MapController>().GetFloor() / 5));
        health *= (1 + (map.GetComponent<MapController>().GetFloor() / 5));
        damage *= (1 + (int)(0.5 * (map.GetComponent<MapController>().GetFloor() / 5)));

        gui = GameObject.FindWithTag("GUI");
        gui.GetComponent<GUI>().ShowBoss();
        gui.GetComponent<GUI>().UpdateBossHP(health, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }   
    }
    public void TakeDamage(float damage)
    {
        Boss2AI boss2 = gameObject.GetComponent<Boss2AI>();

        if (boss2 != null)
        {
            boss2.Explode();
        }

        health -= damage;

        gui.GetComponent<GUI>().UpdateBossHP(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetDamage()
    {
        return damage;
    }
    void Die()
    {
        if (alive)
        {
            for (int i = 0; i < map.GetComponent<MapController>().GetFloor(); i++)
            {
                Instantiate(goldPrefab, gameObject.transform.position, Quaternion.identity);
            }
            alive = false;
            gui.GetComponent<GUI>().HideBoss();
            map.GetComponent<MapController>().SpawnPortal();
            Destroy(gameObject);
        }
    }
}
