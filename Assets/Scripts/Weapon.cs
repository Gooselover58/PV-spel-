using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform shootPoint;
    [SerializeField] WeaponType type;

    private void Start()
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

    public Ranged(Weapon weapon)
    {

    }
}

public class Melee : Weapon
{
    public int damage;
    public float coolDown;
    public Melee()
    {

    }
}

public enum WeaponType
{
    ranged, melee
}