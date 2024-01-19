using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossWeaponHolder : MonoBehaviour
{
    private Sprite noWeapon;
    [SerializeField] GameObject dropped;
    [SerializeField] Image[] weaponArts;
    public BossWeaponScript ws;
    public Holder holder;
    public Weapon currentWeapon;
    public List<Weapon> weaponsInventory;

    private void Start()
    {
        ws = transform.GetChild(0).GetChild(0).GetComponent<BossWeaponScript>();
        ws.weapon = currentWeapon;
        if (holder == Holder.player)
        {
            noWeapon = weaponArts[0].sprite;
            weaponsInventory.Add(currentWeapon);
        }
    }

    private void Update()
    {
        weaponsInventory = weaponsInventory.ToList();
        if (holder == Holder.player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i < weaponsInventory.Count)
                {
                    weaponArts[i].sprite = weaponsInventory[i].weaponArt;
                    if (currentWeapon == weaponsInventory[i])
                    {
                        weaponArts[i].transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                    }
                    else
                    {
                        weaponArts[i].transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
                    }
                }
                else
                {
                    weaponArts[i].sprite = noWeapon;
                    weaponArts[i].transform.parent.GetComponent<Image>().color = Color.white;
                }
            }
            if (Input.GetKeyDown("1"))
            {
                SwitchWeapon(0);
            }
            else if (Input.GetKeyDown("2"))
            {
                SwitchWeapon(1);
            }
            else if (Input.GetKeyDown("3"))
            {
                SwitchWeapon(2);
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
        if (index < weaponsInventory.Count)
        {
            ws.StopCoroutine("CoolDown");
            ws.canAttack = true;
            ws.weapon = weaponsInventory[index];
            currentWeapon = weaponsInventory[index];
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
            SwitchWeapon(0);
        }
    }

    public void PickUpWeapon(GameObject weaponOb)
    {
        if (weaponsInventory.ToList().Count < 3)
        {
            weaponsInventory.Add(weaponOb.GetComponent<DroppedWeapon>().weapon);
        }
        else
        {
            DropWeapon();
            weaponsInventory.Add(weaponOb.GetComponent<DroppedWeapon>().weapon);
        }
    }

    public enum Holder
    {
        player, enemy
    }
}
