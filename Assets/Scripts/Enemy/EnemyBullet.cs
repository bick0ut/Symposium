using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Screen")
        {
            Destroy(gameObject);
        }

        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable()) {
                player.Invulnerable();
                player.TakeDamage(1);
            }
            Destroy(gameObject);
        }

    }
}
