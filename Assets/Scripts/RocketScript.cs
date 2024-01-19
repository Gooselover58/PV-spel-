using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private bool followPlayer;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    [SerializeField] float speed;
    public GameObject player;

    private void Start()
    {
        followPlayer = false;
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        rb.rotation = 150;
        StartCoroutine("AimForPlayer");
    }

    private void FixedUpdate()
    {
        if (followPlayer)
        {
            rb.MovePosition(rb.position + -(Vector2)transform.up * speed * Time.fixedDeltaTime);
            Vector2 dir = rb.position - playerRb.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
        }
        else
        {
            rb.MovePosition(rb.position + -(Vector2)transform.up * speed * Time.fixedDeltaTime);
        }
    }

    IEnumerator AimForPlayer()
    {
        yield return new WaitForSeconds(1);
        followPlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerHealth>() != null)
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(50);
            Destroy(gameObject);
        }
    }
}
