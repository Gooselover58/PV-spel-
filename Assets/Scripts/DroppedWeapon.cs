using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    private SpriteRenderer sp;
    public GameObject weaponOb;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = weaponOb.GetComponent<WeaponScript>().weapon.weaponArt;
    }
}
