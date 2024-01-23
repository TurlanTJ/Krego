using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public ItemSO item;

    public void PopulateSlot(ItemSO item)
    {
        this.item = item;
        _icon.sprite = item.icon;
    }

    public bool ContainsLoot()
    {
        if (item != null)
            return true;

        return false;
    }

    private void ClearSlot()
    {
        _icon.sprite = null;
        item = null;
    }

    public void Loot()
    {
        if (!LootItem())
            return;

        ClearSlot();
    }

    private bool LootItem()
    {
        if (InventoryManager.instance.AddItemToInventory(item))
            return true;

        return false;
    }
}
