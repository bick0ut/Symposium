using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Controller : MonoBehaviour
{
    private PlayerController pc;
    public Transform firePoint;
    public GameObject laserPrefab;
    public GameObject laserBlastPrefab;

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
            Instantiate(laserBlastPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
