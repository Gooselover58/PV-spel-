using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<Vector3> offset;
    [SerializeField] MovmentScript ms;
    private GameObject user;
    private Rigidbody2D rb;
    public float angle;

    void Start()
    {
        user = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouse - rb.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if (ms.y <= 0)
        {
            transform.position = user.transform.position + offset[0];
        }
        else if (ms.y == 1)
        {
            transform.position = user.transform.position + offset[1];
        }
        if (ms.x <= 0)
        {
            transform.position = user.transform.position + offset[2];
        }
        else if (ms.x == 1)
        {
            transform.position = user.transform.position + offset[3];
        }
    }
}
