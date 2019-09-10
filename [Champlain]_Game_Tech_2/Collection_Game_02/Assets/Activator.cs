using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.deactivatePanel();
    }
}
