using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    public GameObject bar;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHP(float health, float maxHealth)
    {
        Vector3 size = new Vector3((health / maxHealth * 60f), 2, 0);
        bar.transform.localScale = size;
    }
}
