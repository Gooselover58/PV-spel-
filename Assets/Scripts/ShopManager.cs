using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject droppedWeapon;
    [SerializeField] GameObject droppedItem;
    [SerializeField] MovmentScript player;
    public GameObject shopWindow;
    [SerializeField] Weapon[] weaponsForSale;
    [SerializeField] Item[] itemsForSale;
    [SerializeField] GameObject[] selection;
    private Transform spawnProducts;

    private void Start()
    {
        RefreshShop();
    }

    public void OpenShop()
    {
        shopWindow.SetActive(true);
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);
    }

    public void RefreshShop()
    {
        shopWindow.SetActive(false);
        spawnProducts = transform.GetChild(0);
        foreach (GameObject item in selection)
        {
            item.SetActive(true);
            int rand = Random.Range(0, itemsForSale.Length + weaponsForSale.Length);
            if (rand < itemsForSale.Length)
            {
                Item product = itemsForSale[rand];
                item.GetComponent<ProductStorage>().ite = product;
                item.transform.GetChild(0).GetComponent<Image>().sprite = product.itemArt;
                item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = product.price + " W";
            }
            else
            {
                Weapon product = weaponsForSale[rand - (itemsForSale.Length)];
                item.GetComponent<ProductStorage>().wea = product;
                item.transform.GetChild(0).GetComponent<Image>().sprite = product.weaponArt;
                item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = product.price + " W";
            }
        }
    }

    public void BuyItemOne()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[0].GetComponent<ProductStorage>().ite != null && selection[0].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[0].GetComponent<ProductStorage>().ite;
            player.money -= selection[0].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[0].GetComponent<ProductStorage>().wea != null && selection[0].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[0].GetComponent<ProductStorage>().wea;
            player.money -= selection[0].GetComponent<ProductStorage>().wea.price;
        }
        selection[0].SetActive(false);
    }

    public void BuyItemTwo()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[1].GetComponent<ProductStorage>().ite != null && selection[1].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[1].GetComponent<ProductStorage>().ite;
            player.money -= selection[1].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[1].GetComponent<ProductStorage>().wea != null && selection[1].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[1].GetComponent<ProductStorage>().wea;
            player.money -= selection[1].GetComponent<ProductStorage>().wea.price;
        }
        selection[1].SetActive(false);
    }
    public void BuyItemThree()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[2].GetComponent<ProductStorage>().ite != null && selection[2].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[2].GetComponent<ProductStorage>().ite;
            player.money -= selection[2].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[2].GetComponent<ProductStorage>().wea != null && selection[2].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[2].GetComponent<ProductStorage>().wea;
            player.money -= selection[2].GetComponent<ProductStorage>().wea.price;
        }
        selection[2].SetActive(false);
    }
    public void BuyItemFour()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[3].GetComponent<ProductStorage>().ite != null && selection[3].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[3].GetComponent<ProductStorage>().ite;
            player.money -= selection[3].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[3].GetComponent<ProductStorage>().wea != null && selection[3].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[3].GetComponent<ProductStorage>().wea;
            player.money -= selection[3].GetComponent<ProductStorage>().wea.price;
        }
        selection[3].SetActive(false);
    }
    public void BuyItemFive()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[4].GetComponent<ProductStorage>().ite != null && selection[4].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[4].GetComponent<ProductStorage>().ite;
            player.money -= selection[4].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[4].GetComponent<ProductStorage>().wea != null && selection[4].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[4].GetComponent<ProductStorage>().wea;
            player.money -= selection[4].GetComponent<ProductStorage>().wea.price;
        }
        selection[4].SetActive(false);
    }
    public void BuyItemSix()
    {
        Vector3 randExtra = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (selection[5].GetComponent<ProductStorage>().ite != null && selection[5].GetComponent<ProductStorage>().ite.price <= player.money)
        {
            GameObject newItem = Instantiate(droppedItem, spawnProducts.position + randExtra, Quaternion.identity);
            newItem.GetComponent<DroppedItem>().item = selection[5].GetComponent<ProductStorage>().ite;
            player.money -= selection[5].GetComponent<ProductStorage>().ite.price;
        }
        else if (selection[5].GetComponent<ProductStorage>().wea != null && selection[5].GetComponent<ProductStorage>().wea.price <= player.money)
        {
            GameObject newWeapon = Instantiate(droppedWeapon, spawnProducts.position + randExtra, Quaternion.identity);
            newWeapon.GetComponent<DroppedWeapon>().weapon = selection[5].GetComponent<ProductStorage>().wea;
            player.money -= selection[5].GetComponent<ProductStorage>().wea.price;
        }
        selection[5].SetActive(false);
    }
}
