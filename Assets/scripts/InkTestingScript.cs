using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkTestingScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
   
   
    // public Text textPrefab;
    public Button buttonPrefab;

    public TextMeshProUGUI textPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interactor._interactableObject != null)
        {
            RefreshUI();
        }
        
        if(Interactor._interactableObject == null)
        {
            eraseUI();
        }
        


    }
    void RefreshUI()
    {
        eraseUI();


       ;

            TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
            string text = loadStoryChunk();


        List<string> tags = story.currentTags;

                         if (tags.Count > 0)
                            {
                               text = "<b>" + tags[0] + "</b> - " + text;
                             }

        storyText.text = text;
        storyText.transform.SetParent(this.transform, false);
            foreach (Choice choice in story.currentChoices)
            {
           


            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);

            Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }


        
    }

    void eraseUI()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    string loadStoryChunk()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.Continue();
            
        }
       
        return text;
    }

  

}
