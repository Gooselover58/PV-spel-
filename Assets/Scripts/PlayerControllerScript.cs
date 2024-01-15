using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private PivotScript ps;
    [SerializeField] float interactionRadius;
    [SerializeField] float MovmentSpeed;
    [SerializeField] float RollSpeed;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource spring; 
    public float x;
    public float y; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = transform.GetChild(0).GetComponent<PivotScript>();
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
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector2 movment = new Vector2(x, y);

        anim.SetFloat("X", y);
        anim.SetFloat("Y", x);
        anim.SetFloat("Speed", movment.sqrMagnitude);

        rb.velocity = movment.normalized * MovmentSpeed;


        if (rb.velocity ==  Vector2.zero)
        {
            spring.mute = true; 
        }
        else
        {
            spring.mute = false; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    public void GoToPs(int dir)
    {
        ps.switchDir(dir);
    }
}
