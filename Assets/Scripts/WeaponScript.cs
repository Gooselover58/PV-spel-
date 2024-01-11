using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] PivotScript ps;
    [SerializeField] GameObject bullet;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform apTran; //apTran = Attack Point TRANsform
    private bool canAttack;
    public WeaponHolder wh;

    private void Awake()
    {
        canAttack = true;
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
        GameObject newBullet = Instantiate(bullet, apTran.position, Quaternion.Euler(0, 0, ps.angle));
        newBullet.GetComponent<BulletScript>().weaponData = weapon;
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