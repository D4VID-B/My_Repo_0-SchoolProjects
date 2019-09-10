using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance = null;

    private int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int amount)
    {
        instance.score += amount;
    }

}
