using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    [SerializeField] private GameObject _inventoryParent;
    [SerializeField] private GameObject _inventorySlot;
    [SerializeField] private List<InventorySlot> _inventorySlotsList = new List<InventorySlot>();

    private InventoryManager _instance;

    private void Start()
    {
        _instance = InventoryManager.instance;

        InitializeInventorySlots(_instance._inventoryCap);
        InventoryManager.instance.onInventoryUpdateAction += UpdateUI;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        int emptySlots = 0;
        foreach(InventorySlot slot in _inventorySlotsList)
        {
            if (slot.IsEmpty())
                emptySlots++;
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _inventorySlotsList.Count; i++)
        {
            if (i < _instance._inventoryList.Count)
            {
                _inventorySlotsList[i].PopulateSlot(_instance._inventoryList[i]);
            }
            else
            {
                _inventorySlotsList[i].ClearSlot();
            }
        }
    }

    public void InitializeInventorySlots(int cap)
    {
        for(int i = 0; i < cap; i++)
        {
            GameObject slot = Instantiate<GameObject>(_inventorySlot, _inventoryParent.transform);
            _inventorySlotsList.Add(slot.GetComponent<InventorySlot>());
        }
    }


}
