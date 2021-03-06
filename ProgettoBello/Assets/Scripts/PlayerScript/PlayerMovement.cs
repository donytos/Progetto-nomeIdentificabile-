using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{//BUG: WHEN THE PLAYER IS IN THE MENU THE BODY STOP MOVING BUT RECORD EVERY RAYCAST DONE DURING THE TIME
            //POSSIBLE SOLUTION: STOP THE RAYCAST
    /** i'm deactivating the camera trigger to testing the Cinemachine without 
   //all the camera in the game scene plus theyr cinemachine
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;
    public CinemachineVirtualCamera camera4;
    public CinemachineClearShot cinemachine1;
    **/

    public NavMeshAgent PlayerAgent; //player agent for the navMesh Movement
    public LayerMask clickable;

    
    public Light lightPlayer;
    /*
    public GameObject player;
    public string a;
    */
    private string colliderTag;  //variable used for choose the correct cam to use

    public Animator objInteraction;

    int collisionMask;
    // Start is called before the first frame update
    void Start()
    {
        /** line of code used to understand the property of how to get the tag of a gameObject
        a = player.gameObject.tag;
        Debug.Log(a);
       */

           PlayerAgent = GetComponent<NavMeshAgent>();

         objInteraction = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       if (UI_Inventory.interaction)
        {
            PlayerAgent.speed = 0;
            StartCoroutine("wait");
           

        }
       else
        {
            PlayerAgent.speed = 2f;
        }
       



        BasicMovement();
        Light();

    }
       IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        UI_Inventory.interaction = false;
    }
    private void BasicMovement()
    {
        //move the player based on the click of the mouse
        //the player will move only on specific layer 
        if (Input.GetMouseButtonDown(0) && !UI_Inventory.inventoryView)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
            
                 collisionMask = (1 << hit.transform.gameObject.layer);
              
            
                if ((clickable.value & collisionMask) > 0)
                {
                    PlayerAgent.destination = hit.point;
                    
                }
                else
                {

                    Debug.Log("Clicked a layer not suitable for navigator");
                }
                  

            }
           
        }
        // BUG: EFFETTUA UN PASSO EXTRA
            //POSSIBILE SOLUZIONE: MODIFICARE I PARAMENTRI DELLA VELOCITA' DI MAGNITUDO
        if (PlayerAgent.velocity.magnitude <=0.1f) { 

            Debug.Log("velocita per togliere " + PlayerAgent.velocity.magnitude);
            objInteraction.SetBool("Movement", false);
        }
        else if (PlayerAgent.velocity.magnitude > 0.1f) { 

            Debug.Log("velocit? per mettere " + PlayerAgent.velocity.magnitude);
            objInteraction.SetBool("Movement", true);
        }
      

    }


    
    private void OnTriggerEnter(Collider other)
    {
        /** i'm deactivating the camera trigger to testing the Cinemachine without 

        //entering a trigger for the camera will deactivate the actual camera to replace it with the new one 
        colliderTag = other.gameObject.tag;
        switch (colliderTag)
        {
            case "CameraTrigger_1":

                Debug.Log("? ENTRATO NEL TRIGGER");
                camera1.gameObject.SetActive(false);
                break;

            case "CameraTrigger_2":

                Debug.Log("? ENTRATO NEL TRIGGER");
                camera2.gameObject.SetActive(false);
                break;

            case "CameraTrigger_3":

                Debug.Log("? ENTRATO NEL TRIGGER");
                camera3.gameObject.SetActive(false);
                break;

            case "CameraTrigger_4":

                Debug.Log("? ENTRATO NEL TRIGGER");
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(false);
                break;

            default:
                break;
        }
        **/
     
      
    }

    private void OnTriggerExit(Collider other)
    {/** i'm deactivating the camera trigger to testing the Cinemachine without 
        //exiting the trigger will restore the camera previousy deactivated
        colliderTag = other.gameObject.tag;

        switch (colliderTag)
        {
            case "CameraTrigger_1":

                Debug.Log("? USCITO DAL TRIGGER");
                camera1.gameObject.SetActive(true);
                break;

            case "CameraTrigger_2":


                Debug.Log("? USCITO DAL TRIGGER");
                camera2.gameObject.SetActive(true);
                break;


            case "CameraTrigger_3":


                Debug.Log("? USCITO DAL TRIGGER");
                camera3.gameObject.SetActive(true);
                break;

            case "CameraTrigger_4":

                Debug.Log("? Uscito NEL TRIGGER");
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(true);
                break;

            default:
                break;
        }
     **/
    }

    public void Light()
    {
   
    
    }

}
