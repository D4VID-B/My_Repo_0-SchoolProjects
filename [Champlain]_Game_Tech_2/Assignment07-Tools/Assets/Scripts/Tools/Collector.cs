using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A tool for searching and collecting a set of user-determined objects as well as providing the user a number of functions base off of the object type.
/// </summary>
public class Collector : MonoBehaviour
{
    public enum ObjectClass
    {
        GameObject,
        Transform,
        Entity,
        Tag,
        Layer,
        Name
    }
    public ObjectClass ObjectType;

    public GameObject theObject;
    public Transform theTransform;
    public Entity theEntity;
    public string objectTag;
    public string objectLayer;
    public string objectName;

    public enum SearchScope
    {
        Search_Scene,
        Search_In_Parent
    }
    public SearchScope Scope;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
