using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouseClick : MonoBehaviour {
    public bool shouldWin;

    private void OnMouseDown()
    {
        if (shouldWin)
        {
            GameManager.instance.Win();
        }else{
            GameManager.instance.Lose();
        }
    }
}
