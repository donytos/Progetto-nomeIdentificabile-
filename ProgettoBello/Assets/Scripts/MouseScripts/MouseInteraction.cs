using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MouseInteraction : MonoBehaviour
{
  TextMeshProUGUI NameObj;
  public  SpriteRenderer sprite;
  public  PlayerBehaviour player_code;
    public GameObject object_show;
  public string str2 = "(UnityEngine.Sprite)";
    public string string3;
    public string TextToShow;
  
    private void Start()
    {
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        NameObj = GameObject.Find("Objname").GetComponent<TextMeshProUGUI>();
       string3 = ("" + sprite.sprite);
       
    }
    private void OnMouseEnter()
    {
        //show the gameobject pointed at whenever the inventory is closed 
            //BUG: The last name selected will remain viewable even after the inventory is opened
        if (!UI_Inventory.inventoryView) { 
        TextToShow = string3.Replace(str2, "");
        NameObj.gameObject.SetActive(true);
        NameObj.SetText("is a " + TextToShow);
        object_show = gameObject;
        }
        //insert a function where when the player move the mouse in the collider box of an object set a visible text that show what that object is
        //maybye using the TAG for an Array of element with the same property will help (?)
    }
    private void OnMouseExit()
    {
        NameObj.gameObject.SetActive(false);
        //Deactivate or Destroy the text 
    }

    private void OnMouseDown()
    {
        NameObj.gameObject.SetActive(false);
        ItemWorld itemWorld = object_show.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //remove the object from the scene if it got picked up
            player_code.inventory.AddItem(itemWorld.GetItems());
            itemWorld.DestroySelf();

        }
    }
}
