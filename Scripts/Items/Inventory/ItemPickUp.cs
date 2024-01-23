using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUpItem(item);
    }

    private void PickUpItem(Item item)
    {
        bool success = InventoryManager.instance.AddItemToInventory(item.itemSO);

        if (success)
            Destroy(gameObject);
        else
            return;
    }
}
