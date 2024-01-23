using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int currentStack = 1;

    public ItemSO itemSO;

    public void UseItem()
    {
        bool success = itemSO.UseItem();

        if (success)
        {
            if(itemSO.isStackable)
                currentStack--;
        }
    }
}
