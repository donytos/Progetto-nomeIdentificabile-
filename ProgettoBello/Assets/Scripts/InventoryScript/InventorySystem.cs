using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    
    public event EventHandler OnItemListChanged; //event for the addition of a new item in the inventory
    public List<Items> itemList;        //list of item in the inventory
   
    //set a new ItemList in the inventory
    public InventorySystem()
    {
        itemList = new List<Items>();

   
        Debug.Log(itemList);
    }

    //function to add an item in the Inventory
    public void AddItem(Items item)
    {
        //check if the item is stackable or we should treath every iteration as a separate object
        if (item.IsStackable())
        {
            //adding a variable to search if the item is already in the inventory
            bool itemAlreadyInInventory = false;
            
            //scan the list of item if the item is in the inventory and is stackable we are not gonna create a new instance of the object in the UI, we're only adding a number to indicate how many instance of that object we have
            foreach (Items inventoryItem in itemList)
            {
                if(inventoryItem.itemtype == item.itemtype)
                {
                    Debug.Log(" ce");
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            // if the item isn't in the inventory we're adding to it
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
       //calling the event handler when we add an item to the inventory
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //return the list of them in the inventory
    public List<Items> GetItemsList()
    {
        return itemList;
    }

 
}

