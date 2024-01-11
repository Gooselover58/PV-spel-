using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Holder holder;
    public WeaponP currentWeapon;
    public List<GameObject> weaponsInventory;

    private void Update()
    {
        if (holder == Holder.player)
        {
            for (int i = 0; i < weaponsInventory.Count; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    SwitchWeapon(i - 1);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentWeapon.Attack();
        }
    }

    private void SwitchWeapon(int index)
    {
    }

    private void DropWeapon(int index)
    {

    }

    public enum Holder
    {
        player, enemy
    }
}
