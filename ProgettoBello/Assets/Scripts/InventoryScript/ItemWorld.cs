using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position,Items item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld,position,Quaternion.identity);

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
    public Items GetItems()
    {
        return item;

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
