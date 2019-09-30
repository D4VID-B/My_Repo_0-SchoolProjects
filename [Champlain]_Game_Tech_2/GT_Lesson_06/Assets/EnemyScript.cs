using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{
    NavMeshAgent enemy;

    public Transform target;
    
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.transform.position);
    }
}
