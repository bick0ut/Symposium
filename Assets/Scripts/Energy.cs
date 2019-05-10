using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private PlayerController pc;

    public GameObject energyBar;
    public GameObject energyBarEmpty;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Tag").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = new Vector3((pc.GetEnergy() / pc.GetMaxEnergy() * 1.0f), 0.1f, 0);
        energyBar.transform.localScale = size;
    }
}
