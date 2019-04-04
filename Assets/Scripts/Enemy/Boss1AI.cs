﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    private GameObject map;
    private GameObject Player;
    private float moveSpeed;

    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;

    public Transform Enemy11;
    public Transform Enemy12;
    public Transform Enemy13;
    public Transform Enemy2;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;
        map = GameObject.FindWithTag("Map");
        Player = map.GetComponent<MapController>().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) {
            float AngleRad = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }

        transform.Translate(new Vector2(2, 0) * moveSpeed * Time.deltaTime);
    }


}
