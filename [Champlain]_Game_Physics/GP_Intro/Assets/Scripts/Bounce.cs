using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    public Rigidbody rb;
    public float bounceStrength = 2;
    public ForceMode mode;

    Vector3 bounceVector = new Vector3();

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");

        bounceVector.y = bounceStrength * 0.981f;

        bounceStrength = bounceVector.y;

        rb.AddForce(bounceVector, mode);

        //Debug.Log("Bounce Strength: " + bounceVector.y.ToString());
        
    }
}
