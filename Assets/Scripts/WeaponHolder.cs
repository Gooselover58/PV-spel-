using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject dropped;
    public Holder holder;
    public WeaponScript currentWeapon;
    public List<WeaponScript> weaponsInventory;

    private void Start()
    {
        weaponsInventory.Add(currentWeapon);
    }

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
            if (Input.GetKey(KeyCode.R) && holder == Holder.player)
            {
                if (currentWeapon != null)
                {
                    currentWeapon.Attack();
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropWeapon();
            }
        }
    }

    private void SwitchWeapon(int index)
    {

    }

    private void DropWeapon()
    {
        if (weaponsInventory.Contains(currentWeapon))
        {
            GameObject newDrop = Instantiate(dropped, transform.position, Quaternion.identity);
            DroppedWeapon dw = newDrop.GetComponent<DroppedWeapon>();
            dw.weapon = currentWeapon.weapon;
            dw.Create();
            weaponsInventory.Remove(currentWeapon);
            currentWeapon = null;
        }
    }

    public enum Holder
    {
        player, enemy
    }
}
