using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthPrefab;
    private GameObject map;

    public float damage;
    public float health = 10;

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

    public float GetDamage()
    {
        return damage;
    }
    void Die()
    {
        if (alive)
        {
            alive = false;
            if (Random.Range(0, 10) == 0)
            {
                Instantiate(healthPrefab, gameObject.transform.position, Quaternion.identity);
            }
            map.GetComponent<MapController>().EnemyKilled();
            Destroy(gameObject);
        }
    }
}
