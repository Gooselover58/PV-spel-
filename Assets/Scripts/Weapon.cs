using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite sprite;
    public Sprite weaponArt;
    public GameObject bullet;
    public AudioClip shootAudio;
    public int damage;
    public float coolDown;
    public float radius;
    public float bulletSpeed;
    public bool piercing;
    public int bulletAmount;
    public float spread;
    public WeaponType type;
}

public enum WeaponType
{
    Ranged, Melee, InfAmmo
}