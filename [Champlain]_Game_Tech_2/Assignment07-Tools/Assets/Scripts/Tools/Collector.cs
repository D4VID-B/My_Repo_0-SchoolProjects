using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A tool for searching and collecting a set of user-determined objects as well as providing the user a number of functions base off of the object type.
/// </summary>
public class Collector : MonoBehaviour
{
#region Enums
    public enum ObjectClass
    {
        GameObject,
        Transform,
        Entity,
    }
    public ObjectClass ObjectType;

    public enum ObjectSearchType
    {
        Tag,
        Layer,
        Name
    }
    public ObjectSearchType SearchBy;

    public enum SearchScope
    {
        Search_Scene,
        Search_In_Parent
    }
    public SearchScope Scope;
#endregion

    public GameObject theObject;
    public Transform theTransform;
    public Entity theEntity;
    public string objectTag;
    public string objectLayer;
    public string objectName;

    public bool listEmpty;
    public GameObject parent;
    public string baseName;
    public int startIndex;

#region The Lists

    [SerializeField]
    public List<GameObject> objectList;

    [SerializeField]
    public List<Transform> transformList;

    [SerializeField]
    public List<Entity> entityList;

    public List<string> printList;

#endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectList != null || transformList != null || entityList != null)
        {
            listEmpty = true;
        }
        else listEmpty = false;
    }

    public void fillObjectList(ObjectSearchType type, bool searchInParent)
    {
        if(searchInParent)
        {
            if (type == ObjectSearchType.Layer)
            {

            }
            else if (type == ObjectSearchType.Name)
            {

            }
            else if (type == ObjectSearchType.Tag)
            {

            }
        }
        else
        {

        }
        
    }

    public void fillTransformList(bool searchInParent)
    {
        if(searchInParent)
        {

        }
        else
        {

        }
    }

    public void fillEntityList(bool searchInParent)
    {
        if(searchInParent)
        {

        }
        else
        {

        }
    }
}
