using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform shootPoint;
    [SerializeField] WeaponType type;
    public int damage;
    public int bulletAmount;
    public float coolDown;
    public float bulletSpeed;


    private void Start()
    {
        shootPoint = transform.GetChild(0);
    }

}

public class Ranged : Weapon
{
    public Ranged(Weapon weapon)
    {

    }
}

public class Melee : Weapon
{

}

public enum WeaponType
{
    ranged, melee
}