using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject endPanel;
    public GameObject gate;

    public static GameManager instance;
    public int score = 0;

    void Awake()
    {
        findObjects();

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

    void Start()
    {
        findObjects();
        endPanel.SetActive(false);
        

        Debug.Log(endPanel.ToString());
    }

    void Update()
    {
        if (score == 16 && SceneManager.GetActiveScene().name == "Level01")
        {
            endPanel.SetActive(true);     //Attempt 1
            //GameObject.Find("EndPanel").SetActive(true);        //Attempt 2
            gate.GetComponent<Gate>().openGate();
            //GameObject.Find("Gate").GetComponent<Gate>().openGate();
        }
        else if (score >= 32 && SceneManager.GetActiveScene().name == "Level02")
        {
            endPanel.SetActive(true);
            //GameObject.Find("EndPanel").SetActive(true);
            gate.GetComponent<Gate>().deactivateGate();
            //GameObject.Find("Gate").GetComponent<Gate>().deactivateGate();
        }
    }


    public void ChangeScore(int amount)
    {
        //ScoreScript.instance.setScore(amount);
        score += amount;

        Debug.Log("Score: " + score);
       
    }

    void findObjects()
    {
        if (endPanel == null)
        {
            endPanel = GameObject.Find("EndPanel");
            endPanel = GameObject.Find("EndPanel02");

            Debug.Log("Panel Found");
        }

        if (gate == null)
        {
            gate = GameObject.Find("Gate");
            gate = GameObject.Find("Gate02");

            Debug.Log("Gate Found");
        }
    }

}
