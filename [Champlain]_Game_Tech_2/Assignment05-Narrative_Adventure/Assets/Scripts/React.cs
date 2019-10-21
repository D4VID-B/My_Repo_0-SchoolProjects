using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React : MonoBehaviour
{

    public Material reaction;

    public List<GameObject> reactionTargets;

    Dictionary<string, Material> originals = new Dictionary<string, Material>();

  public void showInteraction()
    {
       
            foreach (GameObject obj in reactionTargets)
            {
                originals.Add(obj.name, obj.GetComponent<Renderer>().material);

                obj.GetComponent<Renderer>().material = reaction;
            }
           
    }

    public void showExit()
    {
        foreach (GameObject obj in reactionTargets)
        {
            obj.GetComponent<Renderer>().material = originals[obj.name];
        }

        originals.Clear();
    }

    
}
