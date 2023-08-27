using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] Item _item;

    private void Pickup()
    {
        InventoryManager.Instance.Add(_item);
        Destroy(gameObject);
    }

    public void OnTriggerStay(Collider _)
    {
        if (Input.GetAxis(InputStrings.InteractionAxis) == 1)
            Pickup();
    }
}
