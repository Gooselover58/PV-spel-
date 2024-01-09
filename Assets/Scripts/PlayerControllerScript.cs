using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    float MovmentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movment = new Vector2(x, y);

        rb.velocity = movment * MovmentSpeed;
    }
}
