using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float interactionRadius;
    [SerializeField] float MovmentSpeed;
    [SerializeField] float RollSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
            foreach (Collider2D col in cols)
            {
                if (col.gameObject.CompareTag("Interactable"))
                {
                    if (col.gameObject.GetComponent<DialogueScript>() != null)
                    {
                        col.gameObject.GetComponent<DialogueScript>().Talk();
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movment = new Vector2(x, y);

        rb.velocity = movment.normalized * MovmentSpeed;

        float R_x = Input.GetAxisRaw("Horizontal");
        float R_y = Input.GetAxisRaw("Vertical");
        Vector2 Roll = new Vector2(R_x, R_y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.transform.position = (movment.normalized * MovmentSpeed * RollSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
