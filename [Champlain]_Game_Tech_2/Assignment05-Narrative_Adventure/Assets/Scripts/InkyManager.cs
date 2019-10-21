using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkyManager : MonoBehaviour
{

    public TextAsset storyText;
    public Text gameText;
    Story story;

    public Transform choiceHolder;
    public Button choiceButton;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void init()
    {
        story = new Story(storyText.text);
        StartCoroutine(refresh());
    }

    void choiceClick(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        StartCoroutine(refresh());
    }

    void cleanUp()
    {
        //Debug.Log("CleanUp");
        gameText.text = "";

        for (int i = choiceHolder.childCount - 1; i >= 0; --i)
        {
            Destroy(choiceHolder.GetChild(i).gameObject);
        }
    }


    IEnumerator refresh()
    {
        cleanUp();

        string txt = "";
        gameText.text = "";

        while(story.canContinue)
        {
            txt = story.Continue().Trim() + "\n";

            //Debug.Log("Surrent text: " + txt);

            gameText.text += txt;

            yield return new WaitForSeconds(1);

            for(int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];

                //Debug.Log("Shoice: " + choices.text);

                Button button = Instantiate(choiceButton, choiceHolder);
                button.transform.Find("Text").GetComponent<Text>().text = choice.text;

                //if()//Check at what point in the story we are
                //{

                //}

                button.onClick.AddListener(delegate { choiceClick(choice); });
            }

        }
    }

    
}
