using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    //set the sprite of an item in the game in a specific position
    public static ItemWorld SpawnItemWorld(Vector3 position,Items item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld,position,Quaternion.Euler(-94,0,0));

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Items item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;

    public void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.Find("text").GetComponent<TextMeshPro>();
    }

    //change the world item with the corrispective item in the inventory and check if the amount of the item is greater then 1
    public void SetItem(Items item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if(item.amount > 1)
        {
            text.SetText(item.amount.ToString());
        }
        else
        {
            text.SetText("");
        }
    }

    //return the item 
    public Items GetItems()
    {
        return item;

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
