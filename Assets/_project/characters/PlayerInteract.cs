using UnityEngine;

internal interface Interactable
{
    public void Interact();
}

public class PlayerInteract : MonoBehaviour
{


    // Start is called before the first frame update
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            float InteractRange = 2f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, InteractRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out LocationChanche exit))
                {
                    exit.Interact();
                }
            }
        }
    }
}
