using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPivot : MonoBehaviour
{
    public Vector2 dir;
    public float angle;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 curOffset;
    private GameObject user;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;

    private void Start()
    {
        user = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dir = playerRb.position - rb.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        transform.position = user.transform.position + curOffset;
    }
}
