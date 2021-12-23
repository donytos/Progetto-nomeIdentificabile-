using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;
public class PlayerBehaviour : MonoBehaviour
{
    public InventorySystem inventory;  //variable used to store the inventory items

    private Items.ItemType itemNeedeed; //variable used to ask if an item is needeed for some trivia in game

    TextMeshProUGUI keyToProceedText;  //variable used to set a graphic reference in the game as a UI element

    public CinemachineClearShot cinemachine1;  //variable used to select the Cinemachine 

    public GameObject trigger_newScene;  //variable used to upload the new scene in the game in real-time

    private GameObject testAnimDoor;  //variables used to set the animation of the door to continue

    public Animator doorAnim;



    public GameObject chest;
    public Animator chestAnim;
    [SerializeField] private UI_Inventory uiInventory;  //variable used to set a graphical reference to the inventory

    // Start is called before the first frame update

    private void Awake()
    {
        // declaring all the variable and attach them at an Object in the Hierarchy

        cinemachine1 = CinemachineClearShot.FindObjectOfType<CinemachineClearShot>();
        uiInventory = UI_Inventory.FindObjectOfType<UI_Inventory>();
        Debug.Log( uiInventory.gameObject.GetType());
    }
    void Start()
    {
        // declaring all the variable and attach them at an Object in the Hierarchy
        testAnimDoor = GameObject.Find("testPortaAnimazione");
        doorAnim = testAnimDoor.GetComponent<Animator>();
        trigger_newScene = GameObject.Find("Trigger_newScene");
        keyToProceedText = GameObject.Find("ui_Text").GetComponent<TextMeshProUGUI>();

        chest = GameObject.Find("chest");
        chestAnim = chest.GetComponent<Animator>();

        //setting the new Inventory and add it to the relative UI
        inventory = new InventorySystem();
        uiInventory.SetInventory(inventory);
     
        //setting the text for the key invisible
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
            //remove the object from the scene if it got picked up
            inventory.AddItem(itemWorld.GetItems());
            itemWorld.DestroySelf();

        }

        // if the player step into the collider for the door he will open it only if he got with him a specific Object
        if (other.CompareTag("DoorTrigger"))
        {       
            Debug.Log("Entra nel trigger");

            //the specific type of item needeed
            itemNeedeed = Items.ItemType.Key;     
            

            //check if the inventory is not empty 
            if (inventory.GetItemsList() != null)
            {
                //start a search for every item in the inventory to find the right one
                foreach (Items item in inventory.GetItemsList())
                {
                    //if the item is in the inventory the animation will start
                    if (itemNeedeed == item.itemtype)
                    {
                        keyToProceedText.gameObject.SetActive(false);
                        keyToProceedText.SetText("");
                        doorAnim.SetBool("DoorTrig", true);

                    }
                    //if the item isn't in the inventory an helping text will appear
                    else
                    {
                        keyToProceedText.gameObject.SetActive(true);
                        doorAnim.SetBool("DoorTrig", false);
                    }
                }

            }
            //if the inventory is empty an helping text will appear
            else Debug.Log("U don't have any object");
            keyToProceedText.gameObject.SetActive(true);
          

        }

        if (other.CompareTag("TriggerChest"))
        {

            chestAnim.SetBool("nearChest", true);
        }




    }



    private void OnTriggerExit(Collider other)
    {
      //when the player step outside of the trigger for open the door
        if (other.CompareTag("DoorTrigger"))
        {
            keyToProceedText.gameObject.SetActive(false);
            itemNeedeed = Items.ItemType.Key;

            //check if the inventory is not empty 
            if (inventory.GetItemsList() != null)
            {
                //setting the text and the animation to a false to prevent the loop of the animation and the inusual appear of the text
                foreach (Items item in inventory.GetItemsList())
                {
                    if (itemNeedeed == item.itemtype)
                    {
                        keyToProceedText.gameObject.SetActive(false);
                        doorAnim.SetBool("DoorTrig", false);


                    }
                    else
                    {
                        keyToProceedText.gameObject.SetActive(false);
                        doorAnim.SetBool("DoorTrig", false);
                    }
                }

            }
            else if(inventory.GetItemsList() == null)
            {
              
                keyToProceedText.gameObject.SetActive(false);
            }


        }

        if (other.CompareTag("TriggerChest"))
        {

            chestAnim.SetBool("nearChest", false);
        }
    }
}
