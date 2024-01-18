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

    private void Awake()
    {
        hp = enemy.health;
        rb = GetComponent<Rigidbody2D>();
        bp = transform.GetChild(0).GetComponent<BossPivot>();
        wh = GetComponent<BossWeaponHolder>();
        wh.currentWeapon = bossWeapon;
        StartCoroutine("AttackPlayer");
    }

    private void FixedUpdate()
    {
        rb.velocity = bp.dir.normalized * enemy.speed;
    }

    public void TakeDamage(int dmg, BulletScript source)
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


    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator AttackPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(wh.currentWeapon.coolDown);
            wh.ws.Shoot();
        }
    }
}
