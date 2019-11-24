using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet;

    public void fire()
    {
        //Roll a virtual D6
        //if rolled 6, fire
        if(rollToFire())
        {
            Instantiate(bullet, new Vector3(), Quaternion.identity, transform);
        }
    }

    bool rollToFire()
    {
        float roll = Random.Range(1, 7);

        if(roll == 6)
        {
            return true;
        }
        else return false;
    }


}
