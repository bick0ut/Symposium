using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject energyPrefab;

    public Animator walk;
    public Collider2D hitbox;
    public SpriteRenderer sprite;

    private float energy = 100;
    private float maxEnergy = 100;

    private int gold = 0;

    private GameObject map;
    private GameObject gui;
    private GameObject menu;

    public float damage = 1;

    private bool walking;
    private float moveSpeed;
    private float health = 10;
    private float maxHealth = 10;
    private bool invulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(energyPrefab, transform);
        map = GameObject.FindWithTag("Map");
        gui = GameObject.FindWithTag("GUI");
        gui.GetComponent<GUI>().Show();
        moveSpeed = 4f;
        DontDestroyOnLoad(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
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
            TakeDamage(enemy.GetDamage());
        }

        Boss boss = collision.gameObject.GetComponent<Boss>();
        if (boss!= null)
        {
            Invulnerable();
            TakeDamage(boss.GetDamage());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Portal" && Input.GetKey(KeyCode.E))
        {
            map.GetComponent<MapController>().NextRoom();
        }

         if (collision.tag == "Health")
        {
            Heal(1);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Gold")
        {
            ChangeGold(1);
            Destroy(collision.gameObject);
        }
    }

    public float GetEnergy()
    {
        return energy;
    }

    public float GetMaxEnergy()
    {
        return maxEnergy;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetGold()
    {
        return this.gold;
    }

    public void ChangeGold(int change)
    {
        gold += change;
        gui.GetComponent<GUI>().UpdateGold(GetGold());
    }

    public float GetDamage()
    {
        return this.damage;
    }

    public void ChangeDamage(float change)
    {
        this.damage += change;
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
    }

    public void ChangeMaxEnergy(float change)
    {
        this.maxEnergy += change;
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
    }
    public void ChangeMaxHealth(float change)
    {
        this.maxHealth += change;
        Heal(change);
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage());
    }
    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        gui.GetComponent<GUI>().UpdateHP(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        gui.GetComponent<GUI>().UpdateHP(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Invulnerable()
    {
        invulnerable = true;
        Invoke("Vulnerable", 1.5f);
    }

    public bool IsInvulnerable()
    {
        return invulnerable;
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
        gameObject.GetComponent<Weapon3Controller>().enabled = false;
    }

    public void LoseEnergy(float energy)
    {
        this.energy -= energy;
        if (this.energy < 0)
        {
            this.energy = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetKeyUp(KeyCode.E))
        {
            gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(),GetMaxEnergy(),GetDamage());
        }

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

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gui.GetComponent<GUI>().ChangeWeapon(2);
            DisableWeapons();

            gameObject.GetComponent<Weapon3Controller>().enabled = true;
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
        energy++;
        if (energy > GetMaxEnergy())
        {
            energy = GetMaxEnergy();
        }
        if (invulnerable)
        {
            sprite.enabled = !sprite.enabled;
        }
    }
}
