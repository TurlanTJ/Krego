using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image _spriteIcon;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private GameObject _stack;

    private ItemSO _storedItem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulateSlot(ItemSO item)
    {
        _storedItem = item;

        _spriteIcon.sprite = item.icon;
        _itemName.text = item.name;

    }

    public void UseThisItem()
    {
        if (_storedItem == null)
            return;

        _storedItem.UseItem();
        InventoryManager.instance.RemoveFromInventory(_storedItem);
    }

    public ItemSO GetStoredItem()
    {
        return _storedItem;
    }

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }
}
