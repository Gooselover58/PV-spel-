using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    private PlayerHealth ph;
    private MovmentScript ms;
    private WeaponHolder wh;
    private PlayerTutorial pt;
    [SerializeField] GameObject itemNoticeOb;
    [SerializeField] Image itemA;
    [SerializeField] TextMeshProUGUI itemD;
    public GameManager gm;
    public List<Item> items;

    public void Start()
    {
        ph = GetComponent<PlayerHealth>();
        ms = GetComponent<MovmentScript>();
        wh = GetComponent<WeaponHolder>();
        if (GetComponent<PlayerTutorial>() != null)
        {
            pt = GetComponent<PlayerTutorial>();
        }
        itemNoticeOb.SetActive(false);
        gm = ph.gm;
    }

    public void Activate(Item item)
    {
        StartCoroutine(ShowItem(item));
        items.Add(item);
        switch (item.itemName)
        {
            case "Steroids":
                ph.maxHealth += (int)item.increase;
                ph.health += (int)item.increase;
                break;
            case "SpikyBullets":
                wh.ws.extraDmg += item.increase;
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
            case "BlackSquarest":
                ph.dodgeChance += item.increase;
                break;
            case "Cthulhu":
                wh.ws.extraDmg += (int)item.increase / 10;
                ms.MovmentSpeed += item.increase;
                ms.parryRadius += item.increase / 20;
                wh.ws.moreBulletSpeed += item.increase;
                break;
            case "GlassCannon":
                wh.ws.extraDmg *= 2;
                ph.maxHealth /= 2;
                ph.health /= 2;
                break;
            case "Defibrillators":
                ms.extraMoney++;
                break;
            case "ClosetKey":
                if (pt != null)
                {
                    pt.hasKey = true;
                }
                break;
            case "ThePlan":
                if (pt != null)
                {
                    pt.hasMap = true;
                }
                break;
        }
    }

    private IEnumerator ShowItem(Item item)
    {
        itemA.sprite = item.itemArt;
        itemD.text = item.description;
        itemNoticeOb.SetActive(true);
        yield return new WaitForSeconds(5);
        itemNoticeOb.SetActive(false);
    }
}
