using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    void Start()
    {
        GameObject panel = GameManager.instance.findPanel("EndPanel02");
        panel.SetActive(false);

        GameManager.instance.findGate("Gate");
    }
}
