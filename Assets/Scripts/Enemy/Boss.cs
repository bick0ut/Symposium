using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour
{
    private GameObject map;
    private GameObject gui;

    public float damage;
    public float health = 100;

    private void Start()
    {
        map = GameObject.FindWithTag("Map");
        gui = GameObject.FindWithTag("GUI");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

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
        map.GetComponent<MapController>().SpawnPortal();
        Destroy(gameObject);
    }
}
