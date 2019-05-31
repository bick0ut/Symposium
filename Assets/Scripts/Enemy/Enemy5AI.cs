using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5AI : MonoBehaviour
{
    public Transform firePoint;

    private GameObject map;
    private GameObject Player;

    private float moveSpeed;
    public GameObject maskPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var mask = Instantiate(maskPrefab, firePoint.position, firePoint.rotation);
        mask.transform.parent = gameObject.transform;
        moveSpeed = 1.0f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
        if (Player != null)
        {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
    }
}
