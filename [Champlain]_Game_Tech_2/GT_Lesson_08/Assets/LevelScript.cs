using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    int exp;
    public int experience
    {
        get
        {
            return exp;
        }

        set
        {
            if(value < 0)
            {
                exp = 0;
            }
            else
            {
                exp = value;
            }
        }
    }

    public int level { get { return exp/222; } }


}
