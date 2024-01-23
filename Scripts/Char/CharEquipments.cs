using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharEquipments : MonoBehaviour
{
    [SerializeField] protected GameObject _equipmentMainIdlePos;
    [SerializeField] protected GameObject _equipmentMainCombatPos;
    [SerializeField] protected GameObject _equipmentSecondaryIdlePos;
    [SerializeField] protected GameObject _equipmentSecondaryCombatPos;

    [SerializeField] protected GameObject _equipmentMain;
    [SerializeField] protected GameObject _equipmentSecondary;

    protected Character _char;

    private void Start()
    {
        _char = GetComponent<Character>();
    }

    public void UnequipEqipment()
    {
        if (_equipmentMain != null)
        {
            _equipmentMain.transform.parent = null;
            _equipmentMain.transform.SetParent(_equipmentMainIdlePos.transform);
            _equipmentMain.transform.localPosition = Vector3.zero;
            _equipmentMain.transform.localRotation = Quaternion.identity;
            _equipmentMain.transform.localScale = Vector3.one;
        }

        if (_equipmentSecondary != null)
        {
            _equipmentSecondary.transform.parent = null;
            _equipmentSecondary.transform.SetParent(_equipmentSecondaryIdlePos.transform);
            _equipmentSecondary.transform.localPosition = Vector3.zero;
            _equipmentSecondary.transform.localRotation = Quaternion.identity;
            _equipmentSecondary.transform.localScale = Vector3.one;
        }
    }

    public void EquipEquipment()
    {
        if (_equipmentMain != null)
        {
            _equipmentMain.transform.parent = null;
            _equipmentMain.transform.SetParent(_equipmentMainCombatPos.transform);
            _equipmentMain.transform.localPosition = Vector3.zero;
            _equipmentMain.transform.localRotation = Quaternion.identity;
            _equipmentMain.transform.localScale = Vector3.one;
        }

        if (_equipmentSecondary != null)
        {
            _equipmentSecondary.transform.parent = null;
            _equipmentSecondary.transform.SetParent(_equipmentSecondaryCombatPos.transform);
            _equipmentSecondary.transform.localPosition = Vector3.zero;
            _equipmentSecondary.transform.localRotation = Quaternion.identity;
            _equipmentSecondary.transform.localScale = Vector3.one;
        }
    }
}
