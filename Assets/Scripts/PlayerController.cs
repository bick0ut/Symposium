using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject energyPrefab;
    public GameObject menuPrefab;

    public Rigidbody2D body;
    public Animator walk;
    public SpriteRenderer sprite;

    private float energy = 100;
    private float maxEnergy = 100;

    private int gold = 0;

    private GameObject map;
    private GameObject gui;
    private GameObject menu;

    public float damage;

    private bool walking;
    private float moveSpeed;
    private float health = 15;
    private float maxHealth = 15;
    private bool invulnerable = false;

    private int dUpgrade = 0;
    private int eUpgrade = 0;
    private int hUpgrade = 0;

    public AudioSource goldSound;
    public AudioSource hitSound;
    public AudioSource healSound;

    private bool charging;
    private Vector2 goal;

    private int weaponIndex;
    private bool confused;

    private int kills = 0;
    private bool displaying;

    // Start is called before the first frame update
    void Start()
    {
        charging = false;
        confused = false;
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
        if (invulnerable || charging)
        {
            return;
        }
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Invulnerable();
            TakeDamage(enemy.GetDamage());
        }

        Minion minion = collision.gameObject.GetComponent<Minion>();
        if (minion != null)
        {
            Invulnerable();
            TakeDamage(minion.GetDamage());
        }

        Boss boss = collision.gameObject.GetComponent<Boss>();
        if (boss!= null)
        {
            Invulnerable();
            TakeDamage(boss.GetDamage());
        }

        Enemy5AI enemy5 = collision.gameObject.GetComponent<Enemy5AI>();
        if (collision.gameObject.tag == "Mask" || enemy5 != null)
        {
            Confuse(3f);
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
            healSound.Play(0);
            Heal(maxHealth*.1f);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Gold")
        {
            goldSound.Play(0);
            ChangeGold(1);
            Destroy(collision.gameObject);
        }
    }


    public void ChangeMovespeed(float change, float timer)
    {
        if (moveSpeed - change < 0)
        {
            change = moveSpeed;
        }
        this.moveSpeed -= change;
        StartCoroutine(ReturnSpeed(change, timer));
    }

    IEnumerator ReturnSpeed(float change, float timer)
    {
        yield return new WaitForSeconds(timer);
        moveSpeed += change;
    }



    public void Confuse(float timer)
    {
        if (!confused)
        {
            confused = true;
            StartCoroutine(ReturnConfuse(timer));
        }
    }

    IEnumerator ReturnConfuse(float timer)
    {
        yield return new WaitForSeconds(timer);
        confused = false;
    }

    public void ResetSpeed()
    {
        this.moveSpeed = 4.0f;
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

    public void AddKill()
    {
        kills++;
    }
    public int GetKills()
    {
        return this.kills;
    }
    public void ChangeDamage(float change)
    {
        this.damage += change;
        dUpgrade++;
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
    }

    public int DUpgrade()
    {
        return dUpgrade;
    }

    public void ChangeMaxEnergy(float change)
    {
        this.maxEnergy += change;
        eUpgrade++;
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
    }

    public int EUpgrade()
    {
        return eUpgrade;
    }

    public void ChangeMaxHealth(float change)
    {
        this.maxHealth += change;
        Heal(change);
        hUpgrade++;
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
        gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(), GetMaxEnergy(), GetDamage(), GetKills());
    }

    public int HUpgrade()
    {
        return hUpgrade;
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
        hitSound.Play(0);
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        gui.GetComponent<GUI>().UpdateHP(health, maxHealth);
        if (health <= 0)
        {
            Instantiate(menuPrefab);
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
        return invulnerable||charging;
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

    public void Charge(Vector2 goal)
    {
        charging = true;
        body.isKinematic = true;
        this.goal = goal;
    }

    public bool IsCharging()
    {
        return charging;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if(Input.GetAxis("Mouse ScrollWheel") > 0f && weaponIndex!=0)
        {
            weaponIndex--;
            gui.GetComponent<GUI>().ChangeWeapon(weaponIndex);
            DisableWeapons();

            if (weaponIndex == 0)
            {
                gameObject.GetComponent<Weapon1Controller>().enabled = true;
            } else if(weaponIndex == 1)
            {
                gameObject.GetComponent<Weapon2Controller>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Weapon3Controller>().enabled = true;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f && weaponIndex!=2)
        {
            weaponIndex++;
            gui.GetComponent<GUI>().ChangeWeapon(weaponIndex);
            DisableWeapons();

            if (weaponIndex == 0)
            {
                gameObject.GetComponent<Weapon1Controller>().enabled = true;
            } else if(weaponIndex == 1)
            {
                gameObject.GetComponent<Weapon2Controller>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Weapon3Controller>().enabled = true;
            }
        }

        if (charging)
        {
            if ((Vector2)transform.position != goal && energy > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, goal, 4 * moveSpeed * Time.deltaTime);
                LoseEnergy(maxEnergy*0.1f);
            }
            else
            {
                charging = false;
                body.isKinematic = false;
            }
            return;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            gui.GetComponent<GUI>().StatsDisplay(GetMaxHealth(),GetMaxEnergy(),GetDamage(), GetKills());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gui.GetComponent<GUI>().ChangeWeapon(0);
            DisableWeapons();
            weaponIndex = 0;

            gameObject.GetComponent<Weapon1Controller>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gui.GetComponent<GUI>().ChangeWeapon(1);
            DisableWeapons();
            weaponIndex = 1;

            gameObject.GetComponent<Weapon2Controller>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gui.GetComponent<GUI>().ChangeWeapon(2);
            DisableWeapons();
            weaponIndex = 2;

            gameObject.GetComponent<Weapon3Controller>().enabled = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (!confused)
            {
                transform.position += new Vector3(0, (moveSpeed * Time.deltaTime));
            } else
            {
                transform.position += new Vector3(0, -(moveSpeed * Time.deltaTime));
            }
            walking = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (!confused)
            {
                transform.position += new Vector3(0, -(moveSpeed * Time.deltaTime));
            } else
            {
                transform.position += new Vector3(0, (moveSpeed * Time.deltaTime));
            }
            walking = true;
        }
 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (!confused)
            {
                transform.position += new Vector3(-(moveSpeed * Time.deltaTime), 0);
            } else
            {
                transform.position += new Vector3((moveSpeed * Time.deltaTime), 0);
            }

            walking = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (!confused)
            {
                transform.position += new Vector3((moveSpeed * Time.deltaTime), 0);
            } else
            {
                transform.position += new Vector3(-(moveSpeed * Time.deltaTime), 0);
            }

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
        energy += GetMaxEnergy()*0.01f;
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
