using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private InventorySystem inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {

        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate =  itemSlotContainer.transform.Find("ItemSlotTemplate");
        Debug.Log("1 " +itemSlotContainer+" "+itemSlotTemplate);
    }

    // Update is called once per frame
    public void SetInventory(InventorySystem inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventorySystem_OnItemListChanged;
        ResfreshInventoryItems();
    }

    private void InventorySystem_OnItemListChanged(object sender,System.EventArgs e)
    {
        ResfreshInventoryItems();
    }


    private void ResfreshInventoryItems()
    {

        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0, y = 0;
        float itemSlotCellSize = 10f;
        foreach(Items item in inventory.GetItemsList())
        {
            Debug.Log("2 "+itemSlotContainer+" "+ itemSlotTemplate);
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2( x *itemSlotCellSize,y*itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
          
            x +=14;
            
            if (x > 200)
            {
                x = 0;
                y++;
            }
           

        }
    }
}
