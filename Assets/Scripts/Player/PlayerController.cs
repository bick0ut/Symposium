using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator walk;
    public Collider2D hitbox;
    public SpriteRenderer sprite;

    private bool walking;
    private float moveSpeed;
    private int health = 10;
    private float timer = 0;
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Debug.Log("hit");
        if (enemy != null)
        {
            TakeDamage(enemy.getDamage());
        }
    }


    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("health is now " + health);
        Invulnerable();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Invulnerable()
    {
        invulnerable = true;
        hitbox.enabled = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (invulnerable)
        {
            sprite.enabled = !sprite.enabled;
            if (timer > 2) {
                sprite.enabled = true;
                hitbox.enabled = true;
                invulnerable = false;
            }
        }

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, (moveSpeed * Time.deltaTime));
            walking = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -(moveSpeed * Time.deltaTime));
            walking = true;
        }
 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-(moveSpeed * Time.deltaTime), 0);
            walking = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3((moveSpeed * Time.deltaTime), 0);
            walking = true;
        }

        if (walking)
        {
            walk.enabled = true;
        } else
        {
            walk.enabled = false;
        }

        walking = false;

    }
}
