using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    public GameObject Player;

    private float moveSpeed;
    private int health = 10;
    private string entity;  

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        entity = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
    }
}
