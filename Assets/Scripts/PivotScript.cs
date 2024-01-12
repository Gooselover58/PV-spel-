using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3 offset;
    private MovmentScript ms;
    private GameObject user;
    private Rigidbody2D rb;
    public float angle;

    void Start()
    {
        user = transform.parent.gameObject;
        if (ms.GetComponentInParent<MovmentScript>() != null)
        {
            ms = GetComponentInParent<MovmentScript>();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouse - rb.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.position = user.transform.position + offset;
        rb.rotation = angle;
    }
}
