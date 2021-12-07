using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;
public class PlayerBehaviour : MonoBehaviour
{
    private InventorySystem inventory;
    private Items.ItemType itemNeedeed;
    TextMeshProUGUI keyToProceedText;
    public CinemachineClearShot cinemachine1;
    public GameObject trigger_newScene;

    [SerializeField] private UI_Inventory uiInventory;
    // Start is called before the first frame update
    void Start()
    {
        trigger_newScene = GameObject.Find("Trigger_newScene");
      keyToProceedText = GameObject.Find("ui_Text").GetComponent<TextMeshProUGUI>();
        inventory = new InventorySystem();
        uiInventory.SetInventory(inventory);
     
        keyToProceedText.SetText("You need a key to proceed");

        keyToProceedText.gameObject.SetActive(false);

    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItems());
            itemWorld.DestroySelf();

        }
        if (other.CompareTag("DoorTrigger"))
        {
           
            Debug.Log("Entra nel trigger");
            itemNeedeed = Items.ItemType.Key;
            GameObject doorToProceed;
            doorToProceed = GameObject.Find("MainDoor");
            Debug.Log("raggiunge questa parte " + doorToProceed);
            if (inventory.GetItemsList() != null)
            {
                foreach (Items item in inventory.GetItemsList())
                {
                    if (itemNeedeed == item.itemtype)
                    {
                        keyToProceedText.gameObject.SetActive(false);
                        keyToProceedText.SetText("");
                        doorToProceed.transform.Translate(Vector3.up * 200 * Time.deltaTime);

                    }

                    else
                    {
                        keyToProceedText.gameObject.SetActive(true);
                        
                    }
                }

            }
            else Debug.Log("U don't have any object");
            keyToProceedText.gameObject.SetActive(true);
          

        }



       

    }



    private void OnTriggerExit(Collider other)
    {
      
        if (other.CompareTag("DoorTrigger"))
        {
            keyToProceedText.gameObject.SetActive(false);
            itemNeedeed = Items.ItemType.Key;
            GameObject doorToProceed;
            doorToProceed = GameObject.Find("MainDoor");
         
            if (inventory.GetItemsList() != null)
            {
               
                foreach (Items item in inventory.GetItemsList())
                {
                    if (itemNeedeed == item.itemtype)
                    {
                        keyToProceedText.gameObject.SetActive(false);
                        doorToProceed.transform.Translate(Vector3.up * -200 * Time.deltaTime);
                       

                    }
                    else
                    {
                        keyToProceedText.gameObject.SetActive(false);
                    }
                }

            }
            else if(inventory.GetItemsList() == null)
            {
              
                keyToProceedText.gameObject.SetActive(false);
            }


        }
    }
}
