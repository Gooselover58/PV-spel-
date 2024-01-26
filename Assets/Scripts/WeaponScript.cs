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
    public bool canAttack;
    public float extraDmg;
    public float lessCooldown;
    public float moreBulletSpeed;
    private SpriteRenderer sr;
    public Weapon weapon;
    public bool isPlayer;
    public List<Weapon> coolingWeapons;

    private void Awake()
    {
        coolingWeapons.Clear();
        moreBulletSpeed = 0;
        extraDmg = 1;
        lessCooldown = 0;
        ps = GetComponentInParent<PivotScript>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GetComponent<AudioSource>().clip = weapon.shootAudio;
        bullet = weapon.bullet;
        if (isPlayer)
        {
            sr.sprite = weapon.sprite;
        }
    }

    public void Attack()
    {
        if (!coolingWeapons.Contains(weapon))
        {
            StartCoroutine(CoolDown(weapon));
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
            GetComponent<AudioSource>().Play();
            BulletScript bs = newBullet.GetComponent<BulletScript>();
            bs.extraDmg = extraDmg;
            bs.moreBulletSpeed = moreBulletSpeed;
            bs.weaponData = weapon;
            bs.isPlayer = isPlayer;
            if (isPlayer)
            {
                bs.player = ps.player;
            }
        }
    }

    public IEnumerator CoolDown(Weapon weapon)
    {
        coolingWeapons.Add(weapon);
        yield return new WaitForSeconds(weapon.coolDown + lessCooldown);
        if (coolingWeapons.Contains(weapon))
        {
            coolingWeapons.Remove(weapon);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(apTran.position, weapon.radius);
    }
}