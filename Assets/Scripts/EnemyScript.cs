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
    public int hp;
    public GameObject player;
    [SerializeField] WeaponScript ws;
    private ParticleSystem bloodPart;
    private PivotScript ps;
    private WeaponHolder wh;

    private void Awake()
    {
        isAlerted = false;
        hp = enemy.health;
        bloodPart = transform.GetChild(1).GetComponent<ParticleSystem>();
        ps = transform.GetChild(2).GetComponent<PivotScript>();
        ps.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = enemy.weaponSprite;
        wh = GetComponent<WeaponHolder>();
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
            StartCoroutine("AttackPlayer");
        }
    }

    public void TakeDamage(int dmg)
    {
        bloodPart.Play();
        hp -= dmg;
        Alert();
    }

    public void Alert()
    {
        isAlerted = true;
        ps.OnAlert();
    }

    IEnumerator AttackPlayer()
    {
        while (isAlerted)
        {
            yield return new WaitForSeconds(wh.currentWeapon.weapon.coolDown);
            wh.currentWeapon.Shoot();
        }
    }
}
