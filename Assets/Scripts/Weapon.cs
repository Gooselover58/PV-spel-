using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite weaponArt;
    public int damage;
    public float coolDown;
    public float radius;
    public float bulletSpeed;
    public WeaponType type;
}

public enum WeaponType
{
    Ranged, Melee, InfAmmo
}