using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator walk;
    public Collider2D hitbox;
    public SpriteRenderer sprite;

    public GameObject map;
    public GameObject gui;

    private bool walking;
    private float moveSpeed;
    private float health = 10;
    private float maxHealth = 10;
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map");
        gui = GameObject.FindWithTag("GUI");
        gui.GetComponent<GUI>().Show();
        moveSpeed = 4f;
        DontDestroyOnLoad(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (invulnerable)
        {
            return;
        }
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Invulnerable();
            TakeDamage(enemy.getDamage());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Portal" && Input.GetKey(KeyCode.E))
        {
            map.GetComponent<MapController>().NextRoom();
        }
    }


    void TakeDamage(float damage)
    {
        health -= damage;
        gui.GetComponent<GUI>().UpdateHP(health, maxHealth);
        Debug.Log("health is now " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Invulnerable()
    {
        invulnerable = true;
        Invoke("Vulnerable", 1.5f);
    }

    void Vulnerable()
    {
        invulnerable = false;
        sprite.enabled = true;
    }

    private void DisableWeapons()
    {
        gameObject.GetComponent<Weapon1Controller>().enabled = false;
        gameObject.GetComponent<Weapon2Controller>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gui.GetComponent<GUI>().ChangeWeapon(0);
            DisableWeapons();

            gameObject.GetComponent<Weapon1Controller>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gui.GetComponent<GUI>().ChangeWeapon(1);
            DisableWeapons();

            gameObject.GetComponent<Weapon2Controller>().enabled = true;
        }

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

    private void FixedUpdate()
    {
        if (invulnerable)
        {
            sprite.enabled = !sprite.enabled;
        }
    }
}
