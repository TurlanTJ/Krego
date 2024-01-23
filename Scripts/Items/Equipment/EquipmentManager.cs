using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private EquipmentSO[] _equipmentsList;
    [SerializeField] private ConsumableSO[] _consumablesList;

    [SerializeField] private GameObject _weaponEqPos;
    [SerializeField] private GameObject _shieldEqPos;

    private InventoryManager _inventoryInstance;

    private GameObject _mainWeapon;
    private GameObject _secondaryWeapon;

    public delegate void OnEquipmentChanged(EquipmentSO newEquipment, EquipmentSO oldEquipment);
    public OnEquipmentChanged onEquipmentChanged;
    public delegate void OnConsumableChanged(ConsumableSO[] consumables);
    public OnConsumableChanged onConsumableChanged;

    public static EquipmentManager instance;

    #region SimpleSingleton
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _inventoryInstance = InventoryManager.instance;

        int eqSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        _equipmentsList = new EquipmentSO[eqSlots];

        _consumablesList = new ConsumableSO[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach (EquipmentSO eq in _equipmentsList)
            {
                if(eq != null)
                {
                    UnequipItem(eq);
                    break;
                }
            }
        }
    }

    public ConsumableSO[] GetConsumablesList()
    {
        return _consumablesList;
    }

    public void EquipConsumable(ConsumableSO consumable)
    {
        for(var i = 0; i < _consumablesList.Length; i++)
        {
            if(_consumablesList[i] == null)
            {
                _consumablesList[i] = consumable;
                break;
            }
        }

        onConsumableChanged?.Invoke(_consumablesList);
    }

    public void UnequipConsumable(ConsumableSO consumable)
    {
        for (var i = 0; i < _consumablesList.Length; i++)
        {
            if (_consumablesList[i] == consumable)
            {
                _consumablesList[i] = null;
                onConsumableChanged?.Invoke(_consumablesList);
                return;
            }
        }
    }

    public void EquipItem(EquipmentSO equipmentSO)
    {
        int newEqSlot = (int)equipmentSO.EquipmentSlots;
        equipmentSO.mesh.GetComponent<Rigidbody>().isKinematic = true;
        
        if (_equipmentsList[newEqSlot] != null)
        {
            UnequipItem(_equipmentsList[newEqSlot]);
        }

        _equipmentsList[newEqSlot] = equipmentSO;

        _inventoryInstance.RemoveFromInventory(equipmentSO);
        _inventoryInstance.onInventoryUpdateAction?.Invoke();

        if (equipmentSO.EquipmentSlots == EquipmentSlots.MainWeapon)
        {
            _mainWeapon = Instantiate(equipmentSO.mesh, _weaponEqPos.transform);
            _mainWeapon.GetComponent<Rigidbody>().isKinematic = true;
            _mainWeapon.GetComponent<BoxCollider>().enabled = false;
        }

        else if (equipmentSO.EquipmentSlots == EquipmentSlots.SecondaryWeapon)
        {
            _secondaryWeapon = Instantiate(equipmentSO.mesh, _shieldEqPos.transform);
            _secondaryWeapon.GetComponent<Rigidbody>().isKinematic = true;
            _secondaryWeapon.GetComponent<BoxCollider>().enabled = false;
        }

        onEquipmentChanged?.Invoke(equipmentSO, null);

        _inventoryInstance.onEquipmentOrConsumbaleRemoveAction?.Invoke(equipmentSO);
    }

    public void UnequipItem(EquipmentSO equipmentSO)
    {
        int eqSlot = (int)equipmentSO.EquipmentSlots;

        if (_inventoryInstance.AddItemToInventory(equipmentSO))
        {
            if (equipmentSO.EquipmentSlots == EquipmentSlots.MainWeapon)
                Destroy(_mainWeapon);
            else if (equipmentSO.EquipmentSlots == EquipmentSlots.SecondaryWeapon)
                Destroy(_secondaryWeapon);

            _equipmentsList[eqSlot] = null;

            onEquipmentChanged?.Invoke(null, equipmentSO);
        }
    }

    public GameObject GetMainWeapon()
    {
        return _mainWeapon;
    }
    public GameObject GetSecondaryWeapon()
    {
        return _secondaryWeapon;
    }
}
