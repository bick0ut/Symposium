using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        if (x < -11)
        {
            gameObject.transform.position = new Vector3(-10.5f, y);
        }

        if (x > 11)
        {
            gameObject.transform.position = new Vector3(10.5f, y);
        }

         if (y < -4)
        {
            gameObject.transform.position = new Vector3(x, -3.5f);
        }

        if (y > 5)
        {
            gameObject.transform.position = new Vector3(x, 4.5f);
        }
    }
}
