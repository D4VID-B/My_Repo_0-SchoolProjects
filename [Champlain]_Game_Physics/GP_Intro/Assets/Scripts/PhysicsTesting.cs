using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTesting : MonoBehaviour
{

    public Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
        rb.AddTorque(new Vector3(-5f, 3f, 1f), ForceMode.Impulse);

        //rb.AddExplosionForce(5.0f, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z+1f), 2.0f);
    }
}
