using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    
    public void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        
        }

    }
   

}
