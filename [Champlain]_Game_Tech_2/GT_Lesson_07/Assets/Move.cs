using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int dir = 1;
    public float X_pos;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= X_pos || transform.position.x <= -X_pos)
        {
            dir *= -1;
        }

        transform.Translate(Vector3.right * dir * 5f * Time.deltaTime);
    }
}
