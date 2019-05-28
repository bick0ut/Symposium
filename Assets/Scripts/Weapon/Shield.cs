using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        this.transform.position = player.transform.position;

        if (!Input.GetMouseButton(1)||Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
        player.GetComponent<PlayerController>().LoseEnergy(2.5f);
        if (player.GetComponent<PlayerController>().GetEnergy() == 0)
        {
            Destroy(gameObject);
        }
    }
}
