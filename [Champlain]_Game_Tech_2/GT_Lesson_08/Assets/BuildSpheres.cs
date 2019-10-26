using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BuildSpheres : MonoBehaviour
{
    public GameObject prefab;

    public List<GameObject> spheres = new List<GameObject>();

    public void buildSphere()
    {
        GameObject sphere = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        spheres.Add(sphere);
    }

    public void clearSpheres()
    {
        while (spheres.Count > 0)
        {
            GameObject temp = spheres[0];
            spheres.RemoveAt(0);

            Destroy(temp);
        }
    }
}
