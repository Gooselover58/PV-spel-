using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject shopWindow;
    [SerializeField] Weapon[] weaponsForSale;
    [SerializeField] Item[] itemsForSale;
    [SerializeField] List<GameObject> selection;

    private void Start()
    {
        foreach (GameObject item in selection)
        {
            int rand = Random.Range(0, itemsForSale.Length + weaponsForSale.Length);
            if (rand < itemsForSale.Length)
            {
                Item product = itemsForSale[rand];
                item.transform.GetChild(0).GetComponent<Image>().sprite = product.itemArt;
                item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = product.price + " W";
            }
            else
            {
                Weapon product = weaponsForSale[rand - itemsForSale.Length];
                item.transform.GetChild(0).GetComponent<Image>().sprite = product.weaponArt;
                item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = product.price + " W";
            }
        }
    }
}
