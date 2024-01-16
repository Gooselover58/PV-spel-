using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject dropped;
    [SerializeField] Image[] weaponArts;
    public WeaponScript ws;
    public Holder holder;
    public Weapon currentWeapon;
    public List<Weapon> weaponsInventory;

    private void Start()
    {
        ws = transform.GetChild(0).GetChild(0).GetComponent<WeaponScript>();
        if (holder == Holder.player)
        {
            weaponsInventory.Add(currentWeapon);
        }
    }

    private void Update()
    {
        ws.weapon = currentWeapon;
        weaponsInventory = weaponsInventory.ToList();
        if (holder == Holder.player)
        {
            for (int i = 0; i < weaponsInventory.Count; i++)
            {
                weaponArts[i].sprite = weaponsInventory[i].weaponArt;
                if (currentWeapon == weaponsInventory[i])
                {
                    weaponArts[i].transform.parent.GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    weaponArts[i].transform.parent.GetComponent<Image>().color = Color.white;
                }
            }
            for (int i = 0; i < weaponsInventory.ToList().Count; i++)
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
                    ws.Attack();
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
        if (weaponsInventory[index] != null)
        {
            ws.weapon = weaponsInventory[index];
        }
    }

    private void DropWeapon()
    {
        if (weaponsInventory.Contains(currentWeapon))
        {
            GameObject newDrop = Instantiate(dropped, transform.position, Quaternion.identity);
            DroppedWeapon dw = newDrop.GetComponent<DroppedWeapon>();
            dw.weapon = currentWeapon;
            weaponsInventory.Remove(currentWeapon);
            currentWeapon = null;
        }
    }

    public void PickUpWeapon(GameObject weaponOb)
    {
        if (weaponsInventory.ToList().Count < 3)
        {
            weaponsInventory.Add(weaponOb.GetComponent<DroppedWeapon>().weapon);
        }
    }

    public enum Holder
    {
        player, enemy
    }
}
