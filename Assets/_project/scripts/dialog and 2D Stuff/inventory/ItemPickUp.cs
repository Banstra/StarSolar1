using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] Item _item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(_item);
        Destroy(gameObject);
    }
}
