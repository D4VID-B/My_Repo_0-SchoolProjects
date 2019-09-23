using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    bool isOpen = true;
    bool isTweening = false;
    public GameObject itemPrefab;
    public GameObject content;

    public void initItemList()
    {
        for (int i = content.transform.childCount-1; i >= 0; i--) // Destroy all items
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < GameManager.instance.inventoryList.Count; i++)//Create all the items
        {
            GameObject item = Instantiate(itemPrefab, content.transform);
            item.GetComponent<Item>().initItem(GameManager.instance.inventoryList[i]);
        }
    }
    
    public void Toggle()
    {
        if(!isTweening)
        {
            isTweening = true;
            if (isOpen)
            {
                close();
            }
            else
            {
                open();
            }
        }
        
    }

    void close()
    {
        isOpen = false;
        GetComponent<RectTransform>().DOAnchorPosX(250f, 0.25f).OnComplete(reset);
    }

    void open()
    {
        isOpen = true;
        GetComponent<RectTransform>().DOAnchorPosX(0f, 0.5f).OnComplete(reset);
    }

    void reset()
    {
        isTweening = false;
    }
}
