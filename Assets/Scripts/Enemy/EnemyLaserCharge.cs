using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserCharge : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 0.75f);
    }

    void Update()
    {
        transform.localScale += new Vector3(0, 0.02f, 0);
    }

    void Die()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Destroy(gameObject);
    }
}
