using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Items
{
   //create a class for the item and an enumerable variable to insert every item that we can add to the inventory
    public enum ItemType
    {
        Key,
        Map,
        PuzzleItem1,
        PuzzleItem2,

    }

    public ItemType itemtype;

    public int amount; //the amount of a single item


    //get the sprite for every item from the ItemAssets
    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
            case ItemType.Key: return ItemAssets.Instance.KeySprite;
            case ItemType.Map: return ItemAssets.Instance.MapSprite;
            case ItemType.PuzzleItem1: return ItemAssets.Instance.PuzzleItem1Sprite;
            case ItemType.PuzzleItem2: return ItemAssets.Instance.PuzzleItem2Sprite;
        }
    }

    //set the possibility for an Item to be stackable and return the boolean value
    public bool IsStackable()
    {
        switch (itemtype)
        {
            default:
            case ItemType.PuzzleItem1:
                return true;
            case ItemType.Key:
            case ItemType.Map:
            case ItemType.PuzzleItem2:
                return false;



        }
    }
 
}

