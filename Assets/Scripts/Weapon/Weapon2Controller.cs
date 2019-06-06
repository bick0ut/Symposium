using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Controller : MonoBehaviour
{
    private PlayerController pc;
    public Transform firePoint;
    public GameObject laserPrefab;
    public GameObject chargePrefab;

    // Update is called once per frame
    private void Awake()
    {
        pc = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (pc.GetEnergy() < pc.GetMaxEnergy())
            {
                return;
            }

            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pc.Charge(mouse);
            float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            Instantiate(chargePrefab, firePoint.position, Quaternion.Euler(0, 0, AngleDeg));
        }
    }
}
