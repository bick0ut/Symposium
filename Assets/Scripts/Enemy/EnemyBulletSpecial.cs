using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpecial : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float damage;
    public float change;
    public float timer;

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
            player.ChangeMovespeed(change, timer);
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
