using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenClick : MonoBehaviour
{
    int counter = 0;
    public TextMeshProUGUI score;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter++;
        }

        score.text = counter.ToString();

    }
}
