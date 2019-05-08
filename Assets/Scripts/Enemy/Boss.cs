using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour
{
    private GameObject map;
    private GameObject gui;

    public float damage;
    public float health = 100;
    public float maxHealth = 100;

    private bool alive = true;

    private void Start()
    {
        map = GameObject.FindWithTag("Map");
        gui = GameObject.FindWithTag("GUI");
        gui.GetComponent<GUI>().ShowBoss();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        gui.GetComponent<GUI>().UpdateBossHP(health, maxHealth);
        if (health <= 0)
        {
            Die();
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
            alive = false;
            gui.GetComponent<GUI>().HideBoss();
            map.GetComponent<MapController>().SpawnPortal();
            Destroy(gameObject);
        }
    }
}
