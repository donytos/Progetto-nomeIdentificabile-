using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Inventory : MonoBehaviour
{
    
    private InventorySystem inventory;  //set a variable for the player invetory
    private Transform itemSlotContainer; //set a variable for the UI element of the container
    private Transform itemSlotTemplate;  //set a variable for the UI element of the inventory Template
    private bool inventoryView=false;
    private Transform panel;

    public static bool interaction;

    private void Awake()
    {

        //search in the Hierarchy for the container and the template of the inventory
        panel = transform.Find("Panel");
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate =  itemSlotContainer.transform.Find("ItemSlotTemplate");
        Debug.Log("1 " +itemSlotContainer+" "+itemSlotTemplate);
        panel.gameObject.SetActive(inventoryView);
        itemSlotContainer.gameObject.SetActive(inventoryView);
    }

   //set the inventory for the player
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
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.I))
        {
            switch (inventoryView)
            {
                case true:
                    Debug.Log("inventory true");
                    inventoryView = false;
                    panel.gameObject.SetActive(inventoryView);
                    itemSlotContainer.gameObject.SetActive(inventoryView);
                    break;
                case false:
                    inventoryView = true;
                    Debug.Log("inventory false");
                    panel.gameObject.SetActive(inventoryView);
                    itemSlotContainer.gameObject.SetActive(inventoryView);
                    break;

            }
            
        }
        
    }
    //refresh the inventory for every new item
    private void ResfreshInventoryItems()
    {
        //istantiate a new template for every object in the inventory and add it to the inventory with the correct item that will display in the game
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 33, y = 25;
        float itemSlotCellSize = 10f;
        foreach(Items item in inventory.GetItemsList())
        {
            interaction = true;
            Debug.LogWarning("è ENTRATO CON INTERAZIONE " + interaction);
            Debug.Log("2 "+itemSlotContainer+" "+ itemSlotTemplate);
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2( x *itemSlotCellSize,y*itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();

            //setting the text if the item is stackable
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
          //if we reach a boundary we are gonna reset the x-axis and increase the y 
            x +=14;
            
            if (x > 130)
            {
                x = 33;
                y-=10;
            }
           

        }
    }
}
