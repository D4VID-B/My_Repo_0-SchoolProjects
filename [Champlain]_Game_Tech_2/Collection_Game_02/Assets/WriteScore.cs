using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI finalScore;

    public void writeFinalScore()
    {
        finalScore.text = GameManager.instance.score.ToString();
    }

}
