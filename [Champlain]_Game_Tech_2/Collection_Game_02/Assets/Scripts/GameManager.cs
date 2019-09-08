using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Text scoreText;
    int playerScore = 0;

    //public GameObject endPanel;
    
    // Start is called before the first frame update
    void Start()
    {
       // endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScore()
    {
        playerScore++;

        if (playerScore >= 4)
        {
           // scoreText.color = new Color(0, 255, 0);
        }

        //scoreText.text = playerScore.ToString();

        if(playerScore == 5)
        {
          //  endPanel.SetActive(true);
        }
    }

}
