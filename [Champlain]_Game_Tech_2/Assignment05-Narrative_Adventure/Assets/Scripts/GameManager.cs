using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform triggerManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Checks if the collider is part of triggerManager, which holds a number of triggers responsible for game events
    /// </summary>
    /// <param name="col"></param>
    /// <returns></returns>
    public bool isInTriggerList(Collider col, bool leaving)
    {
        bool isInList = false;
        Transform storyTrigger = null;

        foreach(Transform child in triggerManager)
        {
            if(child.gameObject.name == col.name)//Check if the trigger is part of Trigger manager
            {
                isInList = true;
                storyTrigger = child;
            }
        }

        if(isInList && !leaving)//Figure out which one is it
        {
            if(storyTrigger.name == "HerbalistTalk")
            {
                Debug.Log("Encounterd the Herbalist");
                col.GetComponent<React>().showInteraction();
            }
            if(storyTrigger.name == "WallClimb")
            {

                Debug.Log("Found the Base");
                col.GetComponent<React>().showInteraction();
            }
            if(storyTrigger.name == "VillageEnter")
            {

                Debug.Log("Reached the Town");
                col.GetComponent<React>().showInteraction();
            }
            //... etc
        }

        return isInList;
    }
    
}
