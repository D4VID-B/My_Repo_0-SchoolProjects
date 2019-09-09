using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string SCENE_NAME;

    public void OnClick()
    {
        SceneManager.LoadScene(SCENE_NAME);
        return;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Woosh");
            OnClick();
            return;
            
        }

        
    }
}
