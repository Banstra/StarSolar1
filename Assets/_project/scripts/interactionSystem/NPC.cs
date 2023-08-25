using UnityEngine;


public class NPC : MonoBehaviour, interactableObject
{
    //public dialogTrigger dialog;
    [SerializeField] private string Prompt;

    public string InteractionPrompt => Prompt;
    public bool interact(Interactor interactor)
    {
        // dialog = GetComponent<dialogTrigger>();
        // dialog.StartDialog();

        Debug.Log("Talking");
        return true;
    }
}
