using UnityEditor.VersionControl;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private InteractionPointUI _interactionPromptUI;

    private void Start() =>
        Instance = this;

    public void ShowMessage(string message) =>
        _interactionPromptUI.SetUP(message);

    public void CloseDialogueMenu() =>
        _interactionPromptUI.Close();
}

