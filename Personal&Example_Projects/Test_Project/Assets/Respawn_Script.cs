using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Script : MonoBehaviour
{
    Vector3 spawn;

     void Start()
    {
        spawn = transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        transform.position = spawn;

        GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}
