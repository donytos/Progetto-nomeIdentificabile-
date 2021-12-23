using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.IO;
public class GameManager : MonoBehaviour
{
    GameManager Instance { get;  set; } //set an istance of the gameManager
    GameObject player; //set a variable for the player
    PlayerBehaviour playerScript; //set a variable for the playerScript
    GameObject plane; 
   

    //adding a Data class for the important setting to save
   [System.Serializable]
    class Data
    {
       public List<Items> inventory;
       public Vector3 playerpos;
       public  string loadedScene;
    }
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
        //setting an only istance of the gameManager 
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

      //  player.transform.position = new Vector3(-9, 0, 1.8f);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>(); //returning the script

        Debug.Log(SceneManager.GetActiveScene().name);

        plane = GameObject.Find("MoveToScene"); 

    //    player = GameObject.Find("Sphere"); //returning the player object
        if (MenuUiControl.continua) { LoadState(); } // load the game if the variable in the main menù return true
       

    }

    // Update is called once per frame


    //save the istance of the player position, save the inventory of the player and all the loaded scene
    public void SaveState()
    {
        Data data = new Data();
        data.playerpos = player.transform.position - new Vector3(6,0,0.4f);
        data.inventory = playerScript.inventory.GetItemsList();
        data.loadedScene = SceneManager.GetActiveScene().name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("saved successfully");
    }

    public void LoadState()  //loading the scene
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            if(data.loadedScene != "GameScene")
            {
                SceneManager.LoadSceneAsync(data.loadedScene, LoadSceneMode.Additive);
            }
         
            Debug.Log("data preedit: "+data.playerpos);
            Debug.Log("playerpos preedit: "+player.transform.position);
            player.transform.position = data.playerpos ;

            foreach(Items item in data.inventory)
            {
                playerScript.inventory.AddItem(item);
            }
          
        }
    }

    private void OnTriggerEnter(Collider other)
    { //save the game once the player enter the trigger
        if (other.CompareTag("Player"))
        {
            SaveState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }

}
