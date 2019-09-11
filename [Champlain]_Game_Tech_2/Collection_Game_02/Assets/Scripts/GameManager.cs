using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    GameObject gate, panel;

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


    public void ChangeScore(int amount)
    {
        score += amount;

        Debug.Log("Score: " + score);

        checkScore();
       
    }

    void checkScore()
    {
        if (score == 16 && SceneManager.GetActiveScene().name == "Level01")
        {
            openGate();
            showPanel();
        }
        else if (score >= 32 && SceneManager.GetActiveScene().name == "Level02")
        {
            openGate();
            showPanel();
        }
        else if (score >= 42 && SceneManager.GetActiveScene().name == "Level03")
        {
            openGate();
        }
    }

    public void initLevel01(string gateName, string panelName)
    {
        gate = null;
        panel = null;
        gate = GameObject.Find(gateName);
        panel = GameObject.Find(panelName);

        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void initLevel02(string gateName, string panelName)
    {
        gate = null;
        panel = null;
        gate = GameObject.Find(gateName);
        panel = GameObject.Find(panelName);

        if (panel != null)
        {
            panel.SetActive(false);
        }
        
    }

    public void initLevel03(string gateName)
    {
        gate = null;
        panel = null;
        gate = GameObject.Find(gateName);
        
    }

    public string getScore()
    {
        return score.ToString();
    }

    public void setScore(int amount)
    {
        score = amount;
    }
 
    void openGate()
    {
        if(gate != null)
        {
            gate.SetActive(false);
        }
    }

    void showPanel()
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }
}
