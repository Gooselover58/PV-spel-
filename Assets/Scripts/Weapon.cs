using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform shootPoint;

    private void Awake()
    {
        shootPoint = transform.GetChild(0);
    }
}

public class Ranged : Weapon
{
    public int damage;
    public int bulletAmount;
    public float coolDown;
    public float bulletSpeed;

    public Ranged()
    {

    }
}

public class Melee : Weapon
{
    public int damage;
    public float coolDown;
    public Melee(int damage_, float coolDown_)
    {
        damage = damage_;
        coolDown = coolDown_;
    }

    public void Attack()
    {

    }
}
