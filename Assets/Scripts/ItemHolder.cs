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
                ph.maxHealth += item.increase;
                ph.health += item.increase;
                break;
            case "SpikyBullets":
                wh.ws.extraDmg += 2;
                break;
            case "FinishFlag":
                ms.MovmentSpeed += 3;
                break;
        }
    }
}
