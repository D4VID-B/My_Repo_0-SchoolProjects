using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        bool isImportant = GameObject.Find("GameManager").GetComponent<GameManager>().isInTriggerList(other, false);

        if(isImportant)
        {

        }
        else if(other.tag == "Enemy")
        {
            //You died

        }
        else
        {
            //Reached the end of the level, for example

        }

    }

    void OnTriggerExit(Collider other)
    {
        bool isImportant = GameObject.Find("GameManager").GetComponent<GameManager>().isInTriggerList(other, true);

        if(isImportant)
        {
            other.GetComponent<React>().showExit();
        }
    }
}
