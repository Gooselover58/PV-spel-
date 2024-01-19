using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Enemy enemy;
    public Weapon bossWeapon;
    public int hp;
    public GameObject player;
    [SerializeField] BossWeaponScript ws;
    private Rigidbody2D rb;
    private BossPivot bp;
    private BossWeaponHolder wh;
    public bool isAlive;
    private ParticleSystem deathPart;

    private void Awake()
    {
        isAlive = true;
        hp = enemy.health;
        rb = GetComponent<Rigidbody2D>();
        bp = transform.GetChild(0).GetComponent<BossPivot>();
        wh = GetComponent<BossWeaponHolder>();
        deathPart = transform.GetChild(3).GetComponent<ParticleSystem>();
        wh.currentWeapon = bossWeapon;
        StartCoroutine("AttackPlayer");
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            rb.velocity = bp.dir.normalized * enemy.speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int dmg, BulletScript source)
    {
        if (isAlive)
        {
            if (player == null)
            {
                player = source.player;
            }
            hp -= dmg;
            if (hp <= 0)
            {
                Die();
            }
        }
    }


    public void Die()
    {
        isAlive = false;
        deathPart.Play();
        Time.timeScale = 0.5f;
        StartCoroutine("Finale");
    }

    IEnumerator AttackPlayer()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(wh.currentWeapon.coolDown);
            if (isAlive)
            {
                wh.ws.Shoot();
            }
        }
    }

    IEnumerator Finale()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
