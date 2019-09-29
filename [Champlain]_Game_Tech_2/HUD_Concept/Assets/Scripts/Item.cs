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
        itemName.text = item.name;
        Instantiate(item, imageHolder);
        currentItem = item;
    }

    public void activate_Use()
    {
        Debug.Log("Consumed: " + currentItem);
        activate_Remove();
    }

    public void activate_Remove()
    {
        GameManager.instance.inventoryList.Remove(currentItem);
        GameObject.Find("Inventory").GetComponent<Inventory>().initItemList();
    }
}
