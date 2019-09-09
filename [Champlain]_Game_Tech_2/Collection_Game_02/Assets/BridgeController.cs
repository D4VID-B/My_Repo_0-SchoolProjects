using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    public GameObject bridge;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bridge.SetActive(true);
        }
    }
}
