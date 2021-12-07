using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{
    GameManager Instance { get;  set; }
    GameObject player;
    GameObject plane;
   
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }

void Start()
    {
        plane = GameObject.Find("MoveToScene");
        
        player = GameObject.Find("Sphere").GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

 
}
