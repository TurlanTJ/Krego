using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharEquipment : CharEquipments
{

    // Update is called once per frame
    void Update()
    {
        _equipmentMain = EquipmentManager.instance.GetMainWeapon();
        _equipmentSecondary = EquipmentManager.instance.GetSecondaryWeapon();
    }
}
