using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float extraDmg;
    public float moreBulletSpeed;
    public Weapon weaponData;
    public bool isPlayer;
    public GameObject player;
    public GameObject hitInd;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("FinalCountDown");
    }

    private void Update()
    {
        rb.velocity = transform.right * (weaponData.bulletSpeed + moreBulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Terrain"))
        {
            DestroyAndInd(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isPlayer)
        {
            if (col.gameObject.GetComponent<EnemyScript>() != null)
            {
                col.gameObject.GetComponent<EnemyScript>().TakeDamage(Mathf.RoundToInt(weaponData.damage * extraDmg), this);
                if (!weaponData.piercing)
                {
                    DestroyAndInd(true);
                }
            }
            else if (col.gameObject.GetComponent<BossScript>() != null)
            {
                col.gameObject.GetComponent<BossScript>().TakeDamage(Mathf.RoundToInt(weaponData.damage * extraDmg), this);
                if (!weaponData.piercing)
                {
                    DestroyAndInd(true);
                }
            }
        }
        else
        {
            if (col.gameObject.GetComponent<PlayerHealth>() != null)
            {
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(Mathf.RoundToInt(weaponData.damage * extraDmg));
                if (!weaponData.piercing)
                {
                    DestroyAndInd(false);
                }
            }
        }
    }

    IEnumerator FinalCountDown()
    {
        yield return new WaitUntil(() => weaponData != null);
        yield return new WaitForSeconds(weaponData.bulletDuration);
        DestroyAndInd(false);
    }

    private void DestroyAndInd(bool shouldInd)
    {
        if (hitInd != null && shouldInd)
        {
            Instantiate(hitInd, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
