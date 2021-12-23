using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MouseInteraction : MonoBehaviour
{
    TextMeshProUGUI NameObj;
    
    
    private void OnMouseEnter()
    {
        NameObj.SetText(nameof(transform));
        //insert a function where when the player move the mouse in the collider box of an object set a visible text that show what that object is
        //maybye using the TAG for an Array of element with the same property will help (?)
    }
    private void OnMouseExit()
    {
        //Deactivate or Destroy the text 
    }
}
