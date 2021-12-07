using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{

   
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;
    public CinemachineVirtualCamera camera4;
    public NavMeshAgent PlayerAgent;
    public LayerMask clickable;
    /*
    public GameObject player;
    public string a;
    */
    private string colliderTag;

    // Start is called before the first frame update
    void Start()
    {
        /** line of code used to understand the property of how to get the tag of a gameObject
        a = player.gameObject.tag;
        Debug.Log(a);
       */
        PlayerAgent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        BasicMovement();


    }

    private void BasicMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                int collisionMask = (1 << hit.transform.gameObject.layer);
                if ((clickable.value & collisionMask) > 0)
                {
                    PlayerAgent.destination = hit.point;
                }
                else
                    Debug.Log("Clicked a layer not suitable for navigator");

            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        colliderTag = other.gameObject.tag;
        switch (colliderTag)
        {
            case "CameraTrigger_1":

                Debug.Log("è ENTRATO NEL TRIGGER");
                camera1.gameObject.SetActive(false);
                break;

            case "CameraTrigger_2":

                Debug.Log("è ENTRATO NEL TRIGGER");
                camera2.gameObject.SetActive(false);
                break;

            case "CameraTrigger_3":

                Debug.Log("è ENTRATO NEL TRIGGER");
                camera3.gameObject.SetActive(false);
                break;

            case "CameraTrigger_4":

                Debug.Log("è ENTRATO NEL TRIGGER");
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(false);
                break;

            default:
                break;
        }
     
      
    }

    private void OnTriggerExit(Collider other)
    {
        colliderTag = other.gameObject.tag;

        switch (colliderTag)
        {
            case "CameraTrigger_1":

                Debug.Log("è USCITO DAL TRIGGER");
                camera1.gameObject.SetActive(true);
                break;

            case "CameraTrigger_2":


                Debug.Log("è USCITO DAL TRIGGER");
                camera2.gameObject.SetActive(true);
                break;


            case "CameraTrigger_3":


                Debug.Log("è USCITO DAL TRIGGER");
                camera3.gameObject.SetActive(true);
                break;

            case "CameraTrigger_4":

                Debug.Log("è Uscito NEL TRIGGER");
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(true);
                break;

            default:
                break;
        }
     
    }





}
