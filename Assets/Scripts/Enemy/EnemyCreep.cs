using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreep : MonoBehaviour
{
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 4f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
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

    private void Die()
    {
        Destroy(gameObject);
    }
}
