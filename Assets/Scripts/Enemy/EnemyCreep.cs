using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreep : MonoBehaviour
{
    private GameObject map;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map");
        damage *= (1 + (int)(0.5 * (map.GetComponent<MapController>().GetFloor() / 5)));
        Invoke("Die", 5f);
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
                player.TakeDamage(damage);
                player.ChangeMovespeed(0.5f, 2);
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
