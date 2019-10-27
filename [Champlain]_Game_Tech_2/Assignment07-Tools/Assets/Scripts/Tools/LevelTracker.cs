using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{

    public Entity target;

    public enum StatType
    {
        Stamina,
        Level,
        OtherStat
    }
    public StatType Type;

    int exp;

    public int boost;

    public int experience
    {
        get
        {
            return exp;
        }

        set
        {
            if (value < 0)
            {
                exp = 0;
            }
            else
            {
                exp = value;
            }
        }
    }

    public int level
    {
        get { return exp / 222; }
    }


    public void boostLevel(int amount)
    {
        exp += 222 * amount;
    }

    public void resetLevel()
    {
        exp = 0;
    }
}
