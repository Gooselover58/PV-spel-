using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject dropped;
    [SerializeField] Image[] weaponArts;
    public Holder holder;
    public WeaponScript currentWeapon;
    public List<WeaponScript> weaponsInventory;

    private void Start()
    {
        if (holder == Holder.player)
        {
            weaponsInventory.Add(currentWeapon);
        }
    }

    private void Update()
    {
        if (holder == Holder.player)
        {
            for (int i = 0; i < weaponsInventory.Count; i++)
            {
                weaponArts[i].sprite = weaponsInventory[i].weapon.weaponArt;
                if (currentWeapon == weaponsInventory[i])
                {
                    weaponArts[i].transform.parent.GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    weaponArts[i].transform.parent.GetComponent<Image>().color = Color.white;
                }
            }
            for (int i = 0; i < weaponsInventory.Count; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    SwitchWeapon(i - 1);
                }
            }
            if (Input.GetKey(KeyCode.Mouse0) && holder == Holder.player)
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
