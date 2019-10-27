using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{


    #region Entity-WideFunctions

    #region Health
    protected int health;

    int getHealth()
    {
        return health;
    }

    void depleteHealth(int amount)
    {
        health -= amount;
    }

    void increaseHealth(int amount)
    {
        health += amount;
    }

    public void die()
    {
        //remove entity
    }
    #endregion

    public virtual void printName()
    {
        Debug.Log("I am an Entity");
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Init stuff
    }

}
