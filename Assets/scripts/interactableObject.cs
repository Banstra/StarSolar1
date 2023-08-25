using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface interactableObject
{
   public string InteractionPrompt { get; }
   public bool interact(Interactor interactor);
}
