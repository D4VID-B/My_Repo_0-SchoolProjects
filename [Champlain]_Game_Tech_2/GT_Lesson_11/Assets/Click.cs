using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
