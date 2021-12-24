using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MouseInventory : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public Image sprite;
    public TextMeshProUGUI ObjDescription;
   


    public string str2 = "(UnityEngine.Sprite)";
    public string string3;
    public string TextToShow;
    void Start()
    {

        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();

        //
        ObjDescription.gameObject.SetActive(false);

        string3 = ("" + sprite.sprite);
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.name == "Image") {
                    Debug.Log("Hit " + result.gameObject.name);
           
                }
                TextToShow = string3.Replace(str2, "");
                switch (TextToShow)
                {
                    case "key_front ":
                        ObjDescription.gameObject.SetActive(true);
                        ObjDescription.SetText("a key used to open a door");
                        break;
                    case "map ":
                        ObjDescription.gameObject.SetActive(true);
                        ObjDescription.SetText("a map, use it to move around freely");
                        break;

                }
             
            }
        }

    
    }
}
