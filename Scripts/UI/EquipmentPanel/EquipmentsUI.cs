using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentsUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentSlotsParent;
    [SerializeField] private GameObject _equipmentSlot;

    [SerializeField] private GameObject _currSlotHead;
    [SerializeField] private GameObject _currSlotChest;
    [SerializeField] private GameObject[] _currSlotArms;
    [SerializeField] private GameObject _currSlotLeg;
    [SerializeField] private GameObject _currSlotFeet;
    [SerializeField] private GameObject _currSlotMainWeapon;
    [SerializeField] private GameObject _currSlotSecondaryWeapon;

    [SerializeField] private GameObject[] _currConsumables;

    private InventoryManager _inventoryManager;
    private EquipmentManager _equipmentManager;

    private List<GameObject> _instantiatedEqSlots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = InventoryManager.instance;
        _equipmentManager = EquipmentManager.instance;

        _inventoryManager.onEquipmentOrConsumbalePickUpAction += UpdateRequiredSlots;
        _inventoryManager.onEquipmentOrConsumbaleRemoveAction += RemoveSlot;

        _equipmentManager.onEquipmentChanged += UpdateCurrEquipment;

        _equipmentManager.onConsumableChanged += UpdateCurrConsumables;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateCurrEquipment(EquipmentSO newEquipment, EquipmentSO oldEquipment)
    {
        if(oldEquipment != null)
        {
            EquipmentSlots slot = oldEquipment.EquipmentSlots;

            switch (slot)
            {
                case (EquipmentSlots.MainWeapon):
                    _currSlotMainWeapon.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.SecondaryWeapon):
                    _currSlotSecondaryWeapon.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.Head):
                    _currSlotHead.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.Chest):
                    _currSlotChest.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.Arm):
                    foreach (GameObject armSlot in _currSlotArms)
                        armSlot.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.Leg):
                    _currSlotLeg.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
                case (EquipmentSlots.Foot):
                    _currSlotFeet.GetComponentsInChildren<Image>()[1].sprite = null;
                    break;
            }

            return;
        }

        if(newEquipment != null)
        {
            EquipmentSlots slot = newEquipment.EquipmentSlots;

            switch (slot)
            {
                case (EquipmentSlots.MainWeapon):
                    _currSlotMainWeapon.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.SecondaryWeapon):
                    _currSlotSecondaryWeapon.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.Head):
                    _currSlotHead.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.Chest):
                    _currSlotChest.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.Arm):
                    foreach(GameObject armSlot in _currSlotArms)
                        armSlot.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.Leg):
                    _currSlotLeg.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
                case (EquipmentSlots.Foot):
                    _currSlotFeet.GetComponentsInChildren<Image>()[1].sprite = newEquipment.icon;
                    break;
            }

            return;
        }
    }

    private void UpdateCurrConsumables(ConsumableSO[] consumables)
    {
        foreach (GameObject consumbalesSlot in _currConsumables)
        {
            foreach (ConsumableSO consumable in consumables)
            {
                if ((consumbalesSlot.GetComponentsInChildren<Image>()[1].sprite == null) && (consumable != null))
                {
                    Debug.Log("Condition Met");

                    consumbalesSlot.GetComponentsInChildren<Image>()[1].sprite = consumable.icon;
                    break;
                }
            }
        }
    }

    private void UpdateRequiredSlots(ItemSO item)
    {
        InstantiateEquipmentSlot(item);
    }

    private void InstantiateEquipmentSlot(ItemSO equipment)
    {
        GameObject slot = Instantiate(_equipmentSlot, _equipmentSlotsParent.transform);
        slot.GetComponent<EquipmentSlot>().PopulateSlot(equipment);
        _instantiatedEqSlots.Add(slot);
    }

    private void RemoveSlot(ItemSO equipment)
    {
        foreach(GameObject slot in _instantiatedEqSlots)
        {
            if (slot.TryGetComponent(out EquipmentSlot eqSlot))
            {
                if(eqSlot.GetStoredItem().name != equipment.name)
                    continue;

                _instantiatedEqSlots.Remove(slot);
                eqSlot.DeleteSelf();

                return;
            }
        }
    }
}
