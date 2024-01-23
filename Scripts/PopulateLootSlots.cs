using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateLootSlots : MonoBehaviour
{
    [SerializeField] private List<LootSlot> _lootSlots = new List<LootSlot>();

    private List<ItemSO> _spawnedLoot = new List<ItemSO>();

    private bool _allItemsLooted = false;
    private int _occupiedSlots = 0;

    private void Update()
    {

    }

    public void PopulateSlots(List<ItemSO> loot)
    {
        _spawnedLoot = loot;

        for (var i = 0; i < _lootSlots.Count; i++)
        {
            if (i >= loot.Count)
                break;

            if (loot[i] == null)
                return;

            _lootSlots[i].PopulateSlot(loot[i]);
            _occupiedSlots++;
        }
    }

    public bool AllItemsLooted()
    {
        return _allItemsLooted;
    }
}
