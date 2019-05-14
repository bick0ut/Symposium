using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Rigidbody2D rb;
    private bool flipped = false;
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Screen" || collision.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Sword" && !flipped)
        {

            rb.velocity = -rb.velocity;

            Vector3 flip = transform.localScale;
            flip.x *= -1;
            transform.localScale = flip;

            flipped = true;
            GetComponent<Renderer>().material.color = new Color(100,100,100);
        }

        if (!flipped)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                if (!player.IsInvulnerable())
                {
                    player.Invulnerable();
                    player.TakeDamage(1);
                }
                Destroy(gameObject);
            }
        } else
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
