using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipments")]
public class EquipmentSO : ItemSO
{
    public int ArmourModifier;
    public int DamageModifier;

    public EquipmentSlots EquipmentSlots;
    public EquipmentCoverRegions[] EquipmentCoverRegions;

    public override bool UseItem()
    {
        try
        {
            EquipmentManager.instance.EquipItem(this);
            return true;
        }
        catch
        {
            return false;
        }        
    }
}

public enum EquipmentSlots {
    Head,
    Chest,
    Arm,
    Hand,
    Leg,
    Foot,
    MainWeapon,
    SecondaryWeapon
}

public enum EquipmentCoverRegions
{
    None,
    Hair,
    FacialHair,
    Head,
    Neck,
    Chest,
    Arm,
    Hand,
    Leg,
    Foot,
    MainWeapon,
    SecondaryWeapon
}
