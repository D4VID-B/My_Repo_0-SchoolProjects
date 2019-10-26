using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnCube : MonoBehaviour
{
    public GameObject target;

    [ContextMenu("Spawn a Cube")]
    void spawnCube()
    {
        Instantiate(target);
    }

    [ContextMenu("Spawn Cube as a Prefab")]
    void spawnCubePrefab()
    {
        PrefabUtility.InstantiatePrefab(target);
    }
}
