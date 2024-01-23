using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumables")]
public class ConsumableSO : ItemSO
{
    public ConsumableType consumableType;
    public ConsumableEffect consumableEffect;

    public int consumableEffectModifier;
    public float consumableEffectTime;

    public override bool UseItem()
    {
        EquipmentManager.instance.EquipConsumable(this);

        return true;
    }

    public override void Consume()
    {
        PlayerManager.playerManager.GetPlayer().GetComponent<Player>().ApplyEffects(this);
        InventoryManager.instance.RemoveFromInventory(this);
    }
}

public enum ConsumableType
{
    Food,
    Potion
}

public enum ConsumableEffect
{
    Heal,
    SpeedBoost,
    DamageBoost,
    ArmourBoost
}
