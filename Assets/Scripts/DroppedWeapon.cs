using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    private SpriteRenderer sr;
    public Weapon weapon;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = weapon.weaponArt;
        float rotation = Random.Range(-90, 90);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
