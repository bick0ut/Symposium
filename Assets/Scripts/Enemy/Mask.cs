using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private Transform parent;
    private Quaternion rotation;


    private void Awake()
    {
        parent = transform.parent;
        rotation = transform.rotation;
        Physics2D.IgnoreCollision(parent.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
        Vector3 v = new Vector3(parent.transform.position.x, parent.transform.position.y, 0);
        transform.position = v;
    }
    private void Update()
    {
        if (parent == null)
        {
            Destroy(gameObject);
        }
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        this.transform.position = parent.transform.position;
    }

    private void FixedUpdate()
    {

    }
}
