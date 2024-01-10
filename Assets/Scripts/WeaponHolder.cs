using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Holder holder;
    public Weapon currentWeapon;
    public List<Weapon> weaponsInventory;

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
    }

    private void SwitchWeapon(int index)
    {
        currentWeapon = weaponsInventory[index];
    }

    private void DropWeapon(int index)
    {

    }

    public enum Holder
    {
        player, enemy
    }
}
