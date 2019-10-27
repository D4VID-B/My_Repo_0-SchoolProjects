using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtPos : MonoBehaviour
{

    public Vector3 custonSpawnPosition;
    public Vector3 customSpawnRotation;
    public Vector3 customSpawnScale;

    public enum ObjectType
    {
        GameObject,
        Prefab
    }
    public ObjectType Type;

    public enum SpawnChoice
    {
        CustomTransform,
        CameraView
    }
    public SpawnChoice Choice;


    public void spawn()
    {
        //Spawn object based on spawn choice

        Debug.Log("Spawnign Object");
    }
}
