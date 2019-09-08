using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int winCount = 0;
    public int lossCount = 0;

    public static GameManager instance;

    public void Awake()
    {
        if(instance==null)
            instance = this;
    }
    public void Win()
    {
        winCount++;
        UIManager.instance.UpdateUI();
        SwitchScenesManager.instance.LoadWin();
    }
    public void Lose()
    {
        lossCount++;
        UIManager.instance.UpdateUI();
        SwitchScenesManager.instance.LoadLose();
    }
}
