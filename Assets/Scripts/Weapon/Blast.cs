using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    private GameObject player;
    private float trans;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        trans = 1.0f;
        Invoke("Die", 2.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("Test");
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage() * 0.5f);
        }

        Minion minion = collision.GetComponent<Minion>();

        if (minion != null)
        {
            minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage() * 0.5f);
        }

        Boss boss = collision.GetComponent<Boss>();

        if (boss != null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage() * 0.5f);
        }
    }

    void Update()
    {
        trans -= 0.005f;
        gameObject.GetComponent<Renderer>().material.color = new Color(trans,trans,trans);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
