using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public Sprite sprite;
    public Sprite arm;
    public int health;
    public float extDmg;
    public float agroRange;
}
