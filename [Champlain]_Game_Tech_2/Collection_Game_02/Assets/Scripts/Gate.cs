using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float newPosition;


    public void openGate()
    {
        // = Mathf.Lerp(transform.position.z, newPosition.z, Time.deltaTime);

        transform.position = new Vector3 (0f, 0f, newPosition);
        //Debug.Log("Moved to " + transform.position.ToString());
    }

    public void deactivateGate()
    {
        gameObject.SetActive(false);
    }
}
