using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    Camera cam;

    NavMeshAgent player;

    void Start()
    {
        cam = Camera.main;

        player = GetComponent<NavMeshAgent>();


    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
