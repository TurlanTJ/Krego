using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOpening : Interactable
{
    [SerializeField] private List<ItemSO> lootItems = new List<ItemSO>();

    private ItemSpawner _itemSpawner;
    private UIManager _UIManager;

    private bool _beenLooted = false;

    // Start is called before the first frame update
    void Start()
    {
        _itemSpawner = ItemSpawner.instance;
        _UIManager = UIManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (lootItems.Count <= 0)
            _beenLooted = true;
    }

    public override void Interact()
    {
        if (_beenLooted)
            return;

        base.Interact();

        _UIManager.onLootingActionCalled?.Invoke(lootItems);
    }
}
