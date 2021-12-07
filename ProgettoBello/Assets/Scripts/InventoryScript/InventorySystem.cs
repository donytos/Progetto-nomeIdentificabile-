using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    public event EventHandler OnItemListChanged;
    public List<Items> itemList;
   

    public InventorySystem()
    {
        itemList = new List<Items>();

   
        Debug.Log(itemList);
    }

    public void AddItem(Items item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Items inventoryItem in itemList)
            {
                if(inventoryItem.itemtype == item.itemtype)
                {
                    Debug.Log(" ce");
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                Debug.Log("nuun ce");
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
       
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetItemsList()
    {
        return itemList;
    }

 
}

