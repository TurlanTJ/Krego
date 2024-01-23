using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class ItemSO : ScriptableObject
{
    public string id;

    new public string name = "New Item";

    public Sprite icon;

    public GameObject mesh;
    public GameObject meshPref;

    public ItemType[] itemType;

    public bool isStackable;
    public int maxStack;

    public int itemLevel;

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual void Consume()
    {

    }
}

public enum ItemType
{
    Equipment,
    Material,
    Consumable,
    Collectable,
    Currency
}
