using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    #region SimpleSingleton
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
    #endregion

    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _goldUI;

    [SerializeField] private int _gold = 0;

    [SerializeField] public List<ItemSO> _inventoryList { get; private set; }

    public delegate void OnInventoryUpdateAction();
    public OnInventoryUpdateAction onInventoryUpdateAction;

    public delegate void OnEquipmentOrConsumbalePickUpAction(ItemSO item);
    public OnEquipmentOrConsumbalePickUpAction onEquipmentOrConsumbalePickUpAction;
    public delegate void OEquipmentOrConsumbaleRemoveAction(ItemSO item);
    public OEquipmentOrConsumbaleRemoveAction onEquipmentOrConsumbaleRemoveAction;

    public int _inventoryCap = 20;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryList = new List<ItemSO>();

        //_inventoryUI.InitializeInventorySlots(_inventoryCap);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int lastItem = _inventoryList.Count - 1;
            if (lastItem >= 0)
            {
                DropItem(_inventoryList[lastItem]);
            }
        }

        _goldUI.GetComponent<TextMeshProUGUI>().text = _gold.ToString();
    }

    public bool AddItemToInventory(ItemSO item)
    {
        if (item == null || (_inventoryList.Count + 1) > _inventoryCap)
            return false;

        #region Stacking Items --- Requires a Fix
        //if (item.isStackable)
        //{
        //    foreach(ItemSO i in _inventoryList)
        //    {
        //        if (i.id.Equals(item.id))
        //        {
        //            if((itemKVP.Value + item.currentStack) <= itemKVP.Key.maxStack)
        //            {
        //                _inventoryList[itemKVP.Key]++;

        //                onInventoryUpdateAction?.Invoke();
        //                return true;
        //            }

        //            int excessStack = (itemKVP.Value + item.currentStack) - itemKVP.Key.maxStack;
        //            _inventoryList[itemKVP.Key] = itemKVP.Key.maxStack;
        //            item.currentStack = excessStack;

        //            _inventoryList.Add(item.itemSO, item.currentStack);
        //            onInventoryUpdateAction?.Invoke();
        //            return true;
        //        }
        //    }
        //}
        #endregion

        _inventoryList.Add(item);
        onInventoryUpdateAction?.Invoke();
        if(item.itemType.Contains(ItemType.Equipment) || item.itemType.Contains(ItemType.Consumable))
            onEquipmentOrConsumbalePickUpAction?.Invoke(item);
        return true;
    }

    public void DropItem(ItemSO item)
    {
        RemoveFromInventory(item);

        onInventoryUpdateAction?.Invoke();
    }

    public void RemoveFromInventory(ItemSO item)
    {
        _inventoryList.Remove(item);

        onInventoryUpdateAction?.Invoke();
    }
}
