public interface interactableObject
{
    public string InteractionPrompt { get; }
    public bool interact(Interactor interactor);
}
