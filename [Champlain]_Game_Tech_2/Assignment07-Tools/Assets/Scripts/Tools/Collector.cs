using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    [Range(8, 31)]
    public int objectLayer;
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


    public void fillObjectList(ObjectSearchType type, bool searchInParent)
    {
        if(searchInParent)
        {
            if (type == ObjectSearchType.Layer)
            {
                foreach (Transform child in parent.transform)
                {
                    if (child.gameObject.layer == objectLayer && notDuplicate(child))
                    {
                        objectList.Add(child.gameObject);
                        listEmpty = true;
                    }
                }
            }
            else if (type == ObjectSearchType.Name)
            {
                foreach (Transform child in parent.transform)
                {
                    if (child.gameObject.name.Contains(objectName) && notDuplicate(child))
                    {
                        objectList.Add(child.gameObject);
                        listEmpty = true;
                    }
                }
            }
            else if (type == ObjectSearchType.Tag)
            {
                foreach (Transform child in parent.transform)
                {
                    if (child.gameObject.tag == objectTag && notDuplicate(child))
                    {
                        objectList.Add(child.gameObject);
                        listEmpty = true;
                    }
                }
            }
        }
        else
        {
            if (type == ObjectSearchType.Layer)
            {
                foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    if (obj.layer == objectLayer && notDuplicate(obj))
                    {
                        objectList.Add(obj);
                        listEmpty = true;
                    }
                }
            }
            else if (type == ObjectSearchType.Name)
            {
                foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    if (obj.name.Contains(objectName) && notDuplicate(obj))
                    {
                        objectList.Add(obj);
                        listEmpty = true;

                    }
                }
            }
            else if (type == ObjectSearchType.Tag)
            {
                foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    if (obj.tag == objectTag && notDuplicate(obj))
                    {
                        objectList.Add(obj);
                        listEmpty = true;

                    }
                }
            }
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

    #region Duplicate Checks
    bool notDuplicate(GameObject target)
    {
        bool isPresent = true;
        foreach (GameObject obj in objectList)
        {
            if (target == obj)
            {
                isPresent = false;
            }
        }

        return isPresent;
    }

    bool notDuplicate(Transform target)
    {
        bool isPresent = true;
        foreach (Transform obj in transformList)
        {
            if (target == obj)
            {
                isPresent = false;
            }
        }

        return isPresent;
    }

    bool notDuplicate(Entity target)
    {
        bool isPresent = true;
        foreach (Entity obj in entityList)
        {
            if (target == obj)
            {
                isPresent = false;
            }
        }

        return isPresent;
    }

    #endregion

    #region List Functions
    public void sortList(ObjectClass type)
    {
        if(type == ObjectClass.Entity)
        {
            Debug.Log("Sorting Entity List!");
            entityList.Sort();
        }
        else if(type == ObjectClass.Transform)
        {
            Debug.Log("Sorting Transform List!");
            transformList.Sort();

        }
        else if(type == ObjectClass.GameObject)
        {
            Debug.Log("Sorting Object List!");
            objectList.Sort();
        }
    }

    public void clearList(ObjectClass type)
    {
        if (type == ObjectClass.Entity)
        {
            Debug.Log("Clearing Entity List!");
            entityList.Clear();
            listEmpty = false;

        }
        else if (type == ObjectClass.Transform)
        {
            Debug.Log("Clearing Transform List!");
            transformList.Clear();
            listEmpty = false;


        }
        else if (type == ObjectClass.GameObject)
        {
            Debug.Log("Clearing Object List!");
            objectList.Clear();
            listEmpty = false;
        }
    }
    #endregion
}
