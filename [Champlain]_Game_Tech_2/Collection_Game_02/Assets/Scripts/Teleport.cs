using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //other.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
    }
}
