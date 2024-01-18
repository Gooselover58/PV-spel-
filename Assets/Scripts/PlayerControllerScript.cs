using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private PivotScript ps;
    private ItemHolder ih;
    [SerializeField] GameManager gm;
    [SerializeField] Transform parryPoint;
    private bool canParry;
    private bool hasExited;
    private WeaponHolder wh;
    [SerializeField] float interactionRadius;
    public float parryRadius;
    public float MovmentSpeed;
    [SerializeField] float RollSpeed;
    [SerializeField] Animator anim;
    public AudioSource spring;
    [SerializeField] AudioSource parry; 
    public float x;
    public float y; 


    void Start()
    {
        gm.player = this.gameObject;
        canParry = true;
        hasExited = false;
        rb = GetComponent<Rigidbody2D>();
        ps = transform.GetChild(0).GetComponent<PivotScript>();
        ih = GetComponent<ItemHolder>();
        parryPoint = ps.transform.GetChild(1);
        wh = GetComponent<WeaponHolder>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gm.isGameActive)
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
                else if (col.gameObject.CompareTag("Weapon"))
                {
                    wh.PickUpWeapon(col.gameObject);
                    Destroy(col.gameObject);
                }
                else if (col.gameObject.GetComponent<DroppedItem>() != null)
                {
                    ih.Activate(col.gameObject.GetComponent<DroppedItem>().item);
                    Destroy(col.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canParry)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(parryPoint.position, parryRadius);
            canParry = false;
            StartCoroutine("ParryCool");
            foreach (Collider2D col in cols)
            {
                if (col.gameObject.CompareTag("Bullet"))
                {
                    StopCoroutine("ParryCool");
                    canParry = true;
                    Destroy(col.gameObject);
                    parry.Play(); 
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

        if (gm.isGameActive)
        {
            rb.velocity = movment.normalized * MovmentSpeed;
        }


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
        Gizmos.DrawWireSphere(parryPoint.position, parryRadius);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Exit"))
        {
            gm.StartCoroutine("RemoveLevel");
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("ExitCamp"))
        {
            if (!hasExited)
            {
                hasExited = true;
                gm.SpawnNewLevel();
                StartCoroutine("ToExitAgain");
            }
        }
    }

    public void GoToPs(int dir)
    {
        ps.switchDir(dir);
    }

    IEnumerator ToExitAgain()
    {
        yield return new WaitForSeconds(0.1f);
        hasExited = false;
    }

    IEnumerator ParryCool()
    {
        yield return new WaitForSeconds(2);
        canParry = true;
    }
}
