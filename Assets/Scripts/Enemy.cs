using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public Weapon[] possibleWeapons;
    public Sprite sprite;
    public Sprite weaponSprite;
    public int health;
    public float extDmg;
    public float agroRange;
}
