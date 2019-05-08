using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreep : MonoBehaviour
{
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("Die", 10f);
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable())
            {
                player.Invulnerable();
                player.TakeDamage(2);
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
