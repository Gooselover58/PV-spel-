using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private PivotScript ps;
    private GameObject bullet;
    [SerializeField] Transform apTran; //apTran = Attack Point TRANsform
    private bool canAttack;
    private SpriteRenderer sr;
    public Weapon weapon;
    public bool isPlayer;

    private void Awake()
    {
        ps = GetComponentInParent<PivotScript>();
        bullet = weapon.bullet;
        canAttack = true;
        sr = GetComponent<SpriteRenderer>();
        if (isPlayer)
        {
            sr.sprite = weapon.sprite;
        }
    }


    public void Attack()
    {
        if (canAttack)
        {
            StartCoroutine("CoolDown");
            switch (weapon.type)
            {
                case WeaponType.Melee:
                    Swing();
                    break;
                case WeaponType.Ranged:
                    Shoot();
                    break;
            }
        }
    }

    private void Swing()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(apTran.position, weapon.radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<EnemyScript>() != null)
            {
                hit.GetComponent<EnemyScript>().TakeDamage(weapon.damage, null);
            }
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < weapon.bulletAmount; i++)
        {
            float rand = Random.Range(ps.angle - weapon.spread, ps.angle + weapon.spread);
            GameObject newBullet = Instantiate(bullet, apTran.position, Quaternion.Euler(0, 0, rand));
            BulletScript bs = newBullet.GetComponent<BulletScript>();
            bs.weaponData = weapon;
            bs.isPlayer = isPlayer;
            if (isPlayer)
            {
                bs.player = ps.player;
            }
        }
    }

    IEnumerator CoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(weapon.coolDown);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(apTran.position, weapon.radius);
    }
}