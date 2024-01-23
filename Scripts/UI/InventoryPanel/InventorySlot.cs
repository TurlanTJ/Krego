using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _spriteIcon;
    [SerializeField] private GameObject _stack;

    public ItemSO storedItem;

    private void Awake()
    {
        ClearSlot();
    }

    private void Update()
    {

    }

    public bool IsEmpty()
    {
        if (storedItem == null)
            return true;

        return false;
    }

    public void PopulateSlot(ItemSO itemso)
    {
        storedItem = itemso;
        _spriteIcon.sprite = itemso.icon;

        //if (item.Key.isStackable)
        //{
        //    _stack.GetComponentInChildren<TextMeshProUGUI>().text = item.Value.ToString();
        //    _stack.SetActive(true);
        //}

        _spriteIcon.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        storedItem = null;
        _spriteIcon.sprite = null;
        _spriteIcon.gameObject.SetActive(false);
        _stack.GetComponentInChildren<TextMeshProUGUI>().text = 0.ToString();
        _stack.gameObject.SetActive(false);
    }

    public void UseThisItem()
    {
        if (storedItem == null)
            return;

        for(var i = 0; i < storedItem.itemType.Length; i++)
        {
            if (storedItem.itemType[i] == ItemType.Consumable)
            {
                storedItem.Consume();
                return;
            }    
        }

        storedItem.UseItem();
    }
}
