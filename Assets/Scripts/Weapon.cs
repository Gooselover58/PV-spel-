using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform attackPoint;
    public WeaponType type;
    public int damage;
    public float cooldown;
    public bool canAttack;

    public Weapon()
    {
        canAttack = true;
    }

    public IEnumerator CoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}

public class Ranged : Weapon
{
    public int ammoCount;

    public Ranged()
    {
        type = WeaponType.Ranged;
    }

    public void Attack()
    {

    }
}

public class Melee : Weapon
{
    public float radius;
    public Melee()
    {
        type = WeaponType.Melee;
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, radius);
        foreach(Collider2D hit in hits)
        {
            if (hit.gameObject.GetComponent<EnemyScript>() != null)
            {
                hit.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            }
        }
    }
}

public class Gun : Ranged
{
    public Gun()
    {

    }
}


public class Sword : Melee
{
    public Sword()
    {
        damage = 20;
        cooldown = 2;
        radius = 2;
    }
}

public enum WeaponType
{
    Ranged, Melee
}