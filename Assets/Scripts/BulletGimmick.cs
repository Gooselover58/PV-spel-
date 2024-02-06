using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGimmick : MonoBehaviour
{
    private Weapon weaponData;
    [SerializeField] float value;

    private void Start()
    {
        if (GetComponent<BulletScript>().weaponData != null)
        {
            weaponData = GetComponent<BulletScript>().weaponData;
        }
    }

    private void Update()
    {
        if (weaponData.weaponName == "Oswald")
        {
            transform.Rotate(Vector2.right * value);
        }
    }
}
