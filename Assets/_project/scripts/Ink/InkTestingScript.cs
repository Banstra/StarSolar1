using Ink.Runtime;
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
    private void Start()
    {
        story = new Story(inkJSON.text);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interactor._interactableObject != null)
        {
            RefreshUI();
        }

        if (Interactor._interactableObject == null)
        {
            eraseUI();
        }



    }

    private void RefreshUI()
    {
        eraseUI();


        ;

        TextMeshProUGUI storyText = Instantiate(textPrefab);
        string text = loadStoryChunk();


        List<string> tags = story.currentTags;

        if (tags.Count > 0)
        {
            text = "<b>" + tags[0] + "</b> - " + text;
        }

        storyText.text = text;
        storyText.transform.SetParent(transform, false);
        foreach (Choice choice in story.currentChoices)
        {



            Button choiceButton = Instantiate(buttonPrefab);
            choiceButton.transform.SetParent(transform, false);

            Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            choiceButton.onClick.AddListener(delegate
            {
                chooseStoryChoice(choice);
            });
        }



    }

    private void eraseUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    private string loadStoryChunk()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.Continue();

        }

        return text;
    }



}
