using UnityEngine;

public class LocationChanche : MonoBehaviour
{
    [SerializeField] private GameObject transitionExit;
    public void Interact()
    {
        Debug.Log("Interacted");
    }

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Interacted2");
        }
    }
}
