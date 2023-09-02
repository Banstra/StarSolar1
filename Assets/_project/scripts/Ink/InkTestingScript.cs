using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InkTestingScript : KDTimer
{
    public static InkTestingScript Instance { get; private set; }

    public UnityEvent StartDialogue { get; private set; } = new();
    public UnityEvent EndDialogue { get; private set; } = new();
    private Story _story;

    [SerializeField] InteractionPointUI _UI;

    [SerializeField] TMP_Text _text;

    [SerializeField] Button[] _buttons;
    [SerializeField] TMP_Text[] _buttonsText;
    private bool _isChoosing;

    [SerializeField] TextAsset _globals;
    private DialogueVariables _variables;

    private void Awake()
    {
        Instance = this;
        EndDialogue.AddListener(() => _variables.StopListening(_story));
        EndDialogue.AddListener(HideUI);
        StartDialogue.AddListener(() => _variables.StartListening(_story));
        _variables = new(_globals);
    }

    private void Update()
    {
        if (Interactor.Instance.IsDealing)
            if (Input.GetAxis(InputStrings.InteractionAxis) == 1 && _isReady)
            {
                RefreshUI();
                StartCoroutine(CheckKD());
            }
    }

    public void SetDialogue(TextAsset dialogueJSON)
    {
        _story = new Story(dialogueJSON.text);
        StartDialogue.Invoke();
    }

    private void RefreshUI()
    {
        _UI.StartDialogue();
        if (_story == null) return;

        string text = LoadStoryChunk();
        if (text == string.Empty) return;
        List<string> tags = _story.currentTags;

        if (tags.Count > 0)
            text = "<b>" + tags[0] + "</b> - " + text;

        _text.text = text;

        var choices = _story.currentChoices.ToArray();
        var i = 0;
        HideButtons();
        if (choices.Length == 0)
        {
            _isChoosing = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
            foreach (var choice in choices)
            {
                if (i >= _buttons.Length) break;
                _isChoosing = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

                _buttons[i].gameObject.SetActive(true);
                _buttonsText[i].text = choice.text;

                _buttons[i].onClick.AddListener(delegate
                {
                    ChooseStoryChoice(choice);
                });
                i++;
            }
    }

    private void HideButtons()
    {
        foreach (var button in _buttons)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }
    }

    private void HideUI()
    {
        _text.text = string.Empty;
        HideButtons();
        _UI.Close();
        _story = null;
    }

    private void ChooseStoryChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    private string LoadStoryChunk()
    {
        string text = string.Empty;
        if (_story.canContinue)
            text = _story.Continue();
        else if (!_isChoosing)
            EndDialogue.Invoke();

        return text;
    }

    public string GetDataToSave() => _variables.GetDataToVariables();
    public void Load(string story) => _variables.Load(story);
}
