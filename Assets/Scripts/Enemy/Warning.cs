using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 1.0f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
