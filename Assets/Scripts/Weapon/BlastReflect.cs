using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastReflect : MonoBehaviour
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
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable())
            {
                player.Invulnerable();
                player.TakeDamage(player.GetDamage() * 5);
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        trans -= 0.005f;
        gameObject.GetComponent<Renderer>().material.color = new Color(trans, trans, trans);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
