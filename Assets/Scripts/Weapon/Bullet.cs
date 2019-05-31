using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed;
    public Rigidbody2D rb;
    private bool reflect;

    // Start is called before the first frame update
    void Start()
    {
        reflect = false;
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

        if (collision.tag == "Mask" && reflect == false)
        {
            rb.velocity = -rb.velocity;
            reflect = true;
        }
        if (!reflect)
        {

            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
                Destroy(gameObject);
            }

            Minion minion = collision.GetComponent<Minion>();

            if (minion != null)
            {
                minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
                Destroy(gameObject);
            }

            Boss boss = collision.GetComponent<Boss>();

            if (boss != null)
            {
                boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
                Destroy(gameObject);
            }
        } else
        {
            if(collision.tag == "Shield")
            {
                Destroy(gameObject);
            }

            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                if (!player.IsInvulnerable())
                {
                    player.Invulnerable();
                    player.TakeDamage(player.GetDamage());
                }
                Destroy(gameObject);
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
