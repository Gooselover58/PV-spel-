using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private PlayerHealth ph;
    private MovmentScript ms;
    private WeaponHolder wh;
    public GameManager gm;
    public List<Item> items;

    public void Start()
    {
        ph = GetComponent<PlayerHealth>();
        ms = GetComponent<MovmentScript>();
        wh = GetComponent<WeaponHolder>();
        gm = ph.gm;
    }

    public void Activate(Item item)
    {
        items.Add(item);
        switch (item.itemName)
        {
            case "Steroids":
                ph.maxHealth += (int)item.increase;
                ph.health += (int)item.increase;
                break;
            case "SpikyBullets":
                wh.ws.extraDmg += (int)item.increase;
                break;
            case "FinishFlag":
                ms.MovmentSpeed += item.increase;
                break;
            case "Observer":
                ms.parryRadius += item.increase;
                break;
            case "Sunglasses":
                wh.ws.lessCooldown -= item.increase;
                break;
        }
    }
}
