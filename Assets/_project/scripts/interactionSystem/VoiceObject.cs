using UnityEngine;
using UnityEngine.Events;

public class VoiceObject : MonoBehaviour
{
    [SerializeField] private string _prompt;
    [SerializeField] private bool _isDisposable;

    private bool _isUsed;
    public void Interact()
    {
        if (_isDisposable && _isUsed) return;

        Interactor.Instance.ShowMessage(_prompt);
        _isUsed = true;
    }

    public void CloseDialogue() => Interactor.Instance.CloseDialogueMenu();

    public string GetPrompt() => _prompt;
}
