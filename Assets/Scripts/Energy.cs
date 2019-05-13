using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private PlayerController pc;
    private GameObject player;

    public GameObject energyBar;
    public GameObject energyBarEmpty;

    private Quaternion rotation;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
        Vector3 v = new Vector3(player.transform.position.x -0.5f, player.transform.position.y + 0.5f, 0);
        transform.position = v;
    }
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = new Vector3((pc.GetEnergy() / pc.GetMaxEnergy() * 1.0f), 1.0f, 0);
        energyBar.transform.localScale = size;
    }
}
