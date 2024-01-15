using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Enemy enemy;
    public bool isAlerted;
    public bool isAttacking;
    public int hp;
    public GameObject player;
    [SerializeField] WeaponScript ws;
    private ParticleSystem bloodPart;
    private Rigidbody2D rb;
    private PivotScript ps;
    private WeaponHolder wh;

    private void Awake()
    {
        isAlerted = false;
        isAttacking = false;
        hp = enemy.health;
        bloodPart = transform.GetChild(1).GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        ps = transform.GetChild(2).GetComponent<PivotScript>();
        ps.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = enemy.weaponSprite;
        wh = GetComponent<WeaponHolder>();
        int rand = Random.Range(0, enemy.possibleWeapons.Length);
        ws.weapon = enemy.possibleWeapons[rand];
        wh.currentWeapon = ws;
    }

    private void Update()
    {
        if (!isAlerted)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, enemy.agroRange);
            foreach (Collider2D col in cols)
            {
                if (col.GetComponent<MovmentScript>() != null)
                {
                    player = col.gameObject;
                    Alert();
                    break;
                }
            }
        }
        else
        {
            if (!isAttacking)
            {
                StartCoroutine("AttackPlayer");
            }
        }
    }

    private void FixedUpdate()
    {
        if (ps.dir.magnitude < 5 && isAlerted)
        {
            rb.velocity = -ps.dir.normalized * enemy.speed;
        }
        else if (ps.dir.magnitude > 9 && isAlerted)
        {
            rb.velocity = ps.dir.normalized * enemy.speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int dmg, BulletScript source)
    {
        if (player == null)
        {
            player = source.player;
        }
        bloodPart.Play();
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
        if (!isAlerted)
        {
            Alert();
        }
    }

    public void Alert()
    {
        isAlerted = true;
        ps.OnAlert();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        while (isAlerted)
        {
            yield return new WaitForSeconds(wh.currentWeapon.weapon.coolDown);
            wh.currentWeapon.Shoot();
        }
    }
}
