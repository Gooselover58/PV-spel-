using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Weapon weaponData;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("FinalCountDown");
    }

    private void Update()
    {
        rb.velocity = transform.right * weaponData.bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(weaponData.damage);
            if (!weaponData.piercing)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator FinalCountDown()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
