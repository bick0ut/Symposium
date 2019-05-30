using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*0.2f);
        }

        Minion minion = collision.GetComponent<Minion>();

        if (minion != null)
        {
            minion.TakeDamage(player.GetComponent<PlayerController>().GetDamage());
        }


        Boss boss = collision.GetComponent<Boss>();

        if (boss!= null)
        {
            boss.TakeDamage(player.GetComponent<PlayerController>().GetDamage()*0.3f);
        }
    }

    private void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        this.transform.position = player.transform.position;

        if (!Input.GetMouseButton(0)||Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(1.0f, 0, 0);
        player.GetComponent<PlayerController>().LoseEnergy(2);
        if (player.GetComponent<PlayerController>().GetEnergy() == 0)
        {
            Destroy(gameObject);
        }
        if (player == null)
        {
            Destroy(gameObject);
        }
    }
}
