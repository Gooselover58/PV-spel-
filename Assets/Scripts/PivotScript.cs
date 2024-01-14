using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3 offset;
    private GameObject user;
    private Rigidbody2D rb;
    public float angle;
    public EnemyScript es;
    public GameObject player;
    public Rigidbody2D playerRb;
    public bool isPlayer;
    public Vector2 dir;
    private bool isAlerted;

    void Start()
    {
        isPlayer = true;
        user = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        if (user.GetComponent<EnemyScript>() != null)
        {
            isPlayer = false;
        }
        else
        {
            player = user;
        }
    }

    public void OnAlert()
    {
        isAlerted = true;
        if (!isPlayer)
        {
            isPlayer = false;
            es = user.GetComponent<EnemyScript>();
            player = es.player;
            playerRb = player.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (isPlayer)
        {
            Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
            dir = mouse - rb.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        else if (!isPlayer && isAlerted)
        {
            dir = playerRb.position - rb.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        transform.position = user.transform.position + offset;
    }
}
