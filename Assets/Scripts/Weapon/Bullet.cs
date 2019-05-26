using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb.velocity = transform.right * moveSpeed;
        Invoke("Die", 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Screen" || collision.tag == "Terrain")
        {
            Destroy(gameObject);
        }

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
            Destroy(gameObject);
        }

        Boss boss = collision.GetComponent<Boss>();

        if (boss!= null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
