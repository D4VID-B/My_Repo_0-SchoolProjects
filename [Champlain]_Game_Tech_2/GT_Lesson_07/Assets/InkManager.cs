using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class InkManager : MonoBehaviour
{

    public TextAsset inkAsset;
    public TextMeshProUGUI mainText;
    public Transform choiceHolder;
    public GameObject choiceButtonPrefab;

    public Story story;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

     void init()
    {
        story = new Story(inkAsset.text);
        StartCoroutine(refresh());
    }

    IEnumerator refresh()
    {
        string txt = "";
        mainText.text = "";

        while(story.canContinue)
        {
            txt = story.Continue().Trim();
            mainText.text += txt+"\n";
            Debug.Log(txt);

            yield return new WaitForSeconds(1f);
        }
        //There is no more text

        //Check for choices:
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];
            GameObject button = Instantiate(choiceButtonPrefab, choiceHolder);
            Debug.Log(choice.text);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
