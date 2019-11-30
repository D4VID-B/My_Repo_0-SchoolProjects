using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float forward;
    float rot;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical");
        rot = Input.GetAxis("Horizontal");

        rb.AddForce(transform.forward * forward * 20f);

        transform.Rotate(0f, rot * 5f, 0f);
    }
}
