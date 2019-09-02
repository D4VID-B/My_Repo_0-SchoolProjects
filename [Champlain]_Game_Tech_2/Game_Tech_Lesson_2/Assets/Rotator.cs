using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xRot = 3f;
    public float yRot = 3f;
    public float zRot = 3f;

    void Update()
    {
        transform.Rotate(xRot, yRot, zRot);
    }
}
