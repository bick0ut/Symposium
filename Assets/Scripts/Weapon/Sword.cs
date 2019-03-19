using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private GameObject player;
    Vector3 point;
    private int tick;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        point = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, 0);
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        if (tick > 20)
        {
            Destroy(gameObject);
        }
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), 9);
        tick++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(3);
        }

    }
}
