using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    int coreHealth = 3;

    List<Transform> enemies = new List<Transform>();

    void Start()
    {
        foreach(Transform child in this.gameObject.transform)
        {
            if(child.gameObject.tag == "Enemy")
            {
                enemies.Add(child);
            }
        }
        Debug.Log("Enemies found : " + enemies.Count);
    }

    void FixedUpdate()
    {
        foreach(Transform obj in enemies)
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
