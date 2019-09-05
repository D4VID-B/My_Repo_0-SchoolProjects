using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***** Formulas + most of the code is taken from [Game Physics: Engine Development, by Ian Millington] *****/

public class PhysicsFunctions : MonoBehaviour
{
    
}

class CustomVector3
{
    public float x, y, z;

    private float pad;

    void invert()
    {
        x = -x;
        y = -y;
        z = -z;
    }
}
