using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{


    private void OnMouseDown()
    {

        GameObject.Find("GameManager").GetComponent<GameManager>().Collect(gameObject);    
    }


}
