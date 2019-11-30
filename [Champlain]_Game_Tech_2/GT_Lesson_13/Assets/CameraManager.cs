using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> camList;

    public GameObject activeCam;

    // Start is called before the first frame update
    void Start()
    {
        activeCam = camList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeCam != camList[0])
        {
            activeCam.SetActive(false);
            activeCam = camList[0];
            activeCam.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && activeCam != camList[1])
        {
            activeCam.SetActive(false);
            activeCam = camList[1];
            activeCam.SetActive(true);
        }
    }
}
