using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Transform imageHolder;

    GameObject currentItem;

    public void initItem(GameObject item)
    {
        itemName.text = item.name;//Fix
        Instantiate(item, imageHolder);
        currentItem = item;
    }

    public void activate_Use()
    {
        Debug.Log("Consumed: " + currentItem);

        if (currentItem.tag == "Health")
        {
            GameManager.instance.IncreaseHealth();
        }

        activate_Remove();
    }

    public void activate_Remove()
    {
        Debug.Log(currentItem);
        GameManager.instance.inventoryList.Remove(currentItem);
        GameObject.Find("StimInv").GetComponent<Inventory>().initItemList();
    }
}
