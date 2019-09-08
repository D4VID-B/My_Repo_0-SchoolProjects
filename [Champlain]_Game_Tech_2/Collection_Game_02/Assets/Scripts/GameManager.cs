using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    /*public*/ GameObject endPanel;
    /*public*/ GameObject gate;

    //public static GameManager instance;

    void Awake()
    {
        if(endPanel == null)
        {
            endPanel = GameObject.Find("EndPanel");
            Debug.Log("Panel Found");
        }
        
        if(gate == null)
        {
            gate = GameObject.Find("Gate");
            Debug.Log("Gate Found");
        }

        //if (instance == null)
        //{
        //    instance = this;

        //    DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != null)
        //{
        //    Destroy(gameObject);
        //}
    }

    void Start()
    {

        //endPanel.SetActive(false);
        GameObject.Find("EndPanel").SetActive(false);

        Debug.Log(SceneManager.GetActiveScene().ToString());
    }

    void Update()
    {
        if (ScoreScript.instance.getScore() == 16 /*&& SceneManager.GetActiveScene().ToString() == "Level01"*/)
        {
            endPanel.SetActive(true);     //Attempt 1
            //GameObject.Find("EndPanel").SetActive(true);        //Attempt 2
            gate.GetComponent<Gate>().openGate();
            //GameObject.Find("Gate").GetComponent<Gate>().openGate();
        }
        else if (ScoreScript.instance.getScore() >= 32 /*&& SceneManager.GetActiveScene().ToString() == "Level02"*/)
        {
            endPanel.SetActive(true);
            //GameObject.Find("EndPanel").SetActive(true);
            gate.GetComponent<Gate>().deactivateGate();
            //GameObject.Find("Gate").GetComponent<Gate>().deactivateGate();
        }
    }


    public void ChangeScore(int amount)
    {
        ScoreScript.instance.setScore(amount);

        Debug.Log("Score: " + ScoreScript.instance.getScore().ToString());
       
    }

}
