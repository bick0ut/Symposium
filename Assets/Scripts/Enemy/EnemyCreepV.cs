using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreepV : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 5.5f);
        Invoke("Stop", 0.5f);
        rb.velocity = transform.right * moveSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
        }

        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable())
            {
                player.Invulnerable();
                player.TakeDamage(1);
            }
        }
    }

    private void Stop()
    {
        rb.velocity = transform.right * 0;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
