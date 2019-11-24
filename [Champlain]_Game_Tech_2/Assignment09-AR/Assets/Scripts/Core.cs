using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    int coreHealth = 3;

    List<GameObject> enemies;

    void Start()
    {
        foreach(Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }

    void FixedUpdate()
    {
        foreach(GameObject obj in enemies)
        {
            if(obj.GetComponent<EnemyScript>() != null)
            {
                obj.GetComponent<EnemyScript>().fire();
            }
        }
    }

    public void looseHP()
    {
        coreHealth--;

        if(coreHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
