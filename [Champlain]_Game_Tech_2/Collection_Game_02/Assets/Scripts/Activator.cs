using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Activator : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            GameManager.instance.setScore(0);
            GameManager.instance.initLevel01("Gate", "Panel");
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
        {
            GameManager.instance.initLevel02("Gate02", "Panel02");
        }
        else if(SceneManager.GetActiveScene().name == "Level03")
        {
            GameManager.instance.initLevel03("Gate03");
        }
        else if(SceneManager.GetActiveScene().name == "EndScreen")
        {
            GetComponent<WriteScore>().writeFinalScore();
        }
    }
}
