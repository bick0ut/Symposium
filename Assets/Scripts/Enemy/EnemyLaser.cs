using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private GameObject map;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map");
        damage *= (1 + (int)(0.5 * (map.GetComponent<MapController>().GetFloor() / 5)));
        Invoke("Die", .75f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, -0.02f, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!player.IsInvulnerable())
            {
                player.Invulnerable();
                player.TakeDamage(damage);
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
