using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchPanels : MonoBehaviour
{
    public GameObject otherPanel;

    bool isOpen = false;
    bool isTweening = false;

    public float openPosX, closedPosX;
    public float otherOpenPosX, otherClosePosX;

    public float openTime, closeTime;

    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (!isTweening)
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
        otherPanel.GetComponent<RectTransform>().DOAnchorPosX(otherOpenPosX, openTime);
        GetComponent<RectTransform>().DOAnchorPosX(closedPosX, closeTime).OnComplete(reset);
    }

    void open()
    {
        isOpen = true;
        otherPanel.GetComponent<RectTransform>().DOAnchorPosX(otherClosePosX, closeTime);
        GetComponent<RectTransform>().DOAnchorPosX(openPosX, openTime).OnComplete(reset);


    }

    void reset()
    {
        isTweening = false;
    }
}
