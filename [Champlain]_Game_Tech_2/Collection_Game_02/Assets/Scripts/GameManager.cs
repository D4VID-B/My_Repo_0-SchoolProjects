using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject endPanel; //Deactivate in level 2 with a separate script
    public GameObject gate;

    public static GameManager instance;
    public int score = 0;

    void Awake()
    {
        findGate("Gate");
        findPanel("EndPanel");
        flipPanel(false);

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
        //ScoreScript.instance.setScore(amount);
        score += amount;

        Debug.Log("Score: " + score);

        checkScore();
       
    }

    void checkScore()
    {
        if (score == 16 && SceneManager.GetActiveScene().name == "Level01")
        {
            flipPanel(true);

            deactivateGate();

        }
        else if (score >= 32 && SceneManager.GetActiveScene().name == "Level02")
        {
            endPanel = findPanel("EndPanel02");
            
            flipPanel(true);

            deactivateGate();

        }
        else if (score >= 42 && SceneManager.GetActiveScene().name == "Level03")
        { 
            deactivateGate();
        }
    }

    public void findGate(string name)
    {

        if (gate == null)
        {
            gate = GameObject.Find(name);

            //Debug.Log(gate.ToString());
        }
    }

    public void deactivateGate()
    {
        gate.GetComponent<Gate>().deactivateGate();
    }

    public void flipPanel(bool state)
    {
        endPanel.SetActive(state);
    }

    public GameObject findPanel(string name)
    {
        return GameObject.Find(name);
    }
}
