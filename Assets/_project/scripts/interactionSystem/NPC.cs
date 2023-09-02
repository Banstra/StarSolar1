using UnityEngine;

public class NPC : KDTimer
{
    [SerializeField] private TextAsset[] _dialogue;
    private int _needDialogueIndex = 0;

    private bool _isUsed;

    private void Start() =>
        InkTestingScript.Instance.EndDialogue.AddListener(CloseDialogue);

    public void Interact()
    {
        if (_isUsed || !_isReady) return;

        if (_needDialogueIndex >= _dialogue.Length)
            _needDialogueIndex = _dialogue.Length - 1;

        Interactor.Instance.StartDialogue(_dialogue[_needDialogueIndex]);
        _isUsed = true;
    }

    public void CloseDialogue()
    {
        _isUsed = false;
        _needDialogueIndex++;
        StartCoroutine(CheckKD());
    }
}
