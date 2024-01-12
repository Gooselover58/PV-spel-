using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] PivotScript ps;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform apTran; //apTran = Attack Point TRANsform
    private bool canAttack;
    private SpriteRenderer sr;
    public Weapon weapon;
    public WeaponHolder wh;

    private void Awake()
    {
        canAttack = true;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (ps.angle >= -45 && ps.angle <= 45)
        {
            sr.sprite = weapon.sprites[0];
        }
        else if (ps.angle > 135 && ps.angle > -45)
        {
            sr.sprite = weapon.sprites[1];
        }
        else if (ps.angle >= -135 && ps.angle <= 135)
        {
            sr.sprite = weapon.sprites[2];
        }
        else if (ps.angle >= 45 && ps.angle <= 135)
        {
            sr.sprite = weapon.sprites[3];
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
                hit.GetComponent<EnemyScript>().TakeDamage(weapon.damage);
            }
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < weapon.bulletAmount; i++)
        {
            float rand = Random.Range(ps.angle - weapon.spread, ps.angle + weapon.spread);
            GameObject newBullet = Instantiate(bullet, apTran.position, Quaternion.Euler(0, 0, rand));
            newBullet.GetComponent<BulletScript>().weaponData = weapon;
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