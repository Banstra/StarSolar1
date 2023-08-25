using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionPointRadius = 0.5f;
    [SerializeField] LayerMask InteractableMask;
  

    private readonly Collider[] colliders = new Collider[4];
    [SerializeField] private int numFound;
    [SerializeField] private InteractionPointUI InteractionPromptUI;

    public static interactableObject _interactableObject;
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, InteractableMask);
        if (numFound > 0)
        {
             _interactableObject = colliders[0].GetComponent<interactableObject>();
            if(_interactableObject != null)
            {
                if (!InteractionPromptUI.IsDisplayed) InteractionPromptUI.SetUP(_interactableObject.InteractionPrompt);
                if (Input.GetKeyDown(KeyCode.E)) {
                    _interactableObject.interact(this);
                     
                }
                
            }
        }
        else
        {
           if(_interactableObject != null) _interactableObject = null;
            if (InteractionPromptUI.IsDisplayed) InteractionPromptUI.Close();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }

}

