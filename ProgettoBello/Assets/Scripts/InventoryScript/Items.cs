using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Items
{
   
    public enum ItemType
    {
        Key,
        Map,
        PuzzleItem1,
        PuzzleItem2,

    }

    public ItemType itemtype;
    public int amount;



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

