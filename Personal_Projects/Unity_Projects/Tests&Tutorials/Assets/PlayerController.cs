using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera MAIN_CAMERA;
    public NavMeshAgent PLAYER;

    Ray ray;
    RaycastHit hitPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = MAIN_CAMERA.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitPoint))
            {
                PLAYER.SetDestination(hitPoint.point);
            }
        }
    }
}
