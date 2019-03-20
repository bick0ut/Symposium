using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthPrefab;
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
        if (Random.Range(0, 10)==0)
        {
            Instantiate(healthPrefab, gameObject.transform.position, Quaternion.identity);
        }
        map.GetComponent<MapController>().EnemyKilled();
        Destroy(gameObject);
    }
}
