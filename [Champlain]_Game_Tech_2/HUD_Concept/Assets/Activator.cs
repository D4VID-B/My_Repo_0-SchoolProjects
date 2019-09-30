using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animation>().playAutomatically = false;
        GetComponent<Animation>().enabled = false;
    }

}
