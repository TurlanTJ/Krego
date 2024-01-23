using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<ItemSO> _availableItems = new List<ItemSO>();

    public static ItemSpawner instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ItemSO> SpawnLoot(int lootLevel)
    {
        int numberOfLoots = (int)Random.Range(1f, 5f);

        List<ItemSO> loot = new List<ItemSO>();

        switch (lootLevel)
        {
            case 1:
                for(var i = 0; i < numberOfLoots; i++)
                {
                    loot.Add(GetItemSO(lootLevel));
                }
                break;
            case 2:
                for (var i = 0; i < numberOfLoots; i++)
                {
                    loot.Add(GetItemSO(lootLevel));
                }
                break;
            case 3:
                for (var i = 0; i < numberOfLoots; i++)
                {
                    loot.Add(GetItemSO(lootLevel));
                }
                break;
            case 4:
                for (var i = 0; i < numberOfLoots; i++)
                {
                    loot.Add(GetItemSO(lootLevel));
                }
                break;
            case 5:
                for (var i = 0; i < numberOfLoots; i++)
                {
                    loot.Add(GetItemSO(lootLevel));
                }
                break;

        }

        return loot;
    }

    private ItemSO GetItemSO (int level)
    {
        foreach(ItemSO itemso in _availableItems)
        {
            if (itemso.itemLevel == level)
                return itemso;
        }

        return null;
    }
}
