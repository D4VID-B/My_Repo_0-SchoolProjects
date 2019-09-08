using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text winTF;
    public Text lossTF;
    public static UIManager instance;
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        
        //If instance already exists and it's not this:
        }
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    public void UpdateUI()
    {
        winTF.text = GameManager.instance.winCount.ToString();
        lossTF.text = GameManager.instance.lossCount.ToString();
    }
}
