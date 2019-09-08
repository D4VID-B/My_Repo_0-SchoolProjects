using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwitchScenesManager : MonoBehaviour {


    public static SwitchScenesManager instance = null;//Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject winLossCanvasPrefab;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //check for Win_Loss_Canvas
        if (UIManager.instance == null)
            Instantiate(winLossCanvasPrefab);
    }
 
    public void LoadStart()
    {
        SceneManager.LoadScene("Start_Scene");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }
    public void LoadWin()
    {
        SceneManager.LoadScene("Win_Scene");
        Invoke("LoadStart", 2f);
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("Lose_Scene");
        Invoke("LoadStart", 2f);
    }
}


