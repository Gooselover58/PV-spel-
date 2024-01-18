using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private PlayerHealth ph;
    private MovmentScript ms;
    private WeaponHolder wh;
    [SerializeField] GameObject itemNoticeOb;
    public GameManager gm;
    public List<Item> items;

    public void Start()
    {
        ph = GetComponent<PlayerHealth>();
        ms = GetComponent<MovmentScript>();
        wh = GetComponent<WeaponHolder>();
        itemNoticeOb.SetActive(false);
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
            case "SpeedyBullets":
                wh.ws.moreBulletSpeed += item.increase;
                break;
            case "Vodka":
                ph.health += (int)item.increase;
                break;
        }
    }
}
