using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3[] offsets;
    private Vector3 curOffset;
    private GameObject user;
    private Rigidbody2D rb;
    private SpriteRenderer wSr;
    private SpriteRenderer aSr;
    public float angle;
    public EnemyScript es;
    public GameObject player;
    public Rigidbody2D playerRb;
    public bool isPlayer;
    public Vector2 dir;
    private bool isAlerted;

    void Start()
    {
        curOffset = offsets[0];
        isPlayer = true;
        user = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        wSr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (user.GetComponent<EnemyScript>() != null)
        {
            isPlayer = false;
        }
        else
        {
            aSr = transform.GetChild(2).GetComponent<SpriteRenderer>();
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
            /*if (dir.magnitude > 2)
            {
                cam.GetComponent<CameraScript>().offset = new Vector3(mouse.normalized.x, mouse.normalized.y, -10);
            }
            else
            {
                cam.GetComponent<CameraScript>().offset = new Vector3(0, 0, -10);
            }*/
        }
        else if (!isPlayer && isAlerted)
        {
            dir = playerRb.position - rb.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        transform.position = user.transform.position + curOffset;
    }

    public void switchDir(int dir)
    {
        if (dir == 1 || dir == 2)
        {
            wSr.sortingOrder = -1;
            aSr.sortingOrder = -1;
        }
        else
        {
            wSr.sortingOrder = 0;
            aSr.sortingOrder = 1;
        }
        curOffset = offsets[dir - 1];
    }
}
