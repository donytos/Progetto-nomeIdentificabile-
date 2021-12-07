using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.IO;
public class GameManager : MonoBehaviour
{
    GameManager Instance { get;  set; }
    GameObject player;
    PlayerBehaviour playerScript;
    GameObject plane;
   [System.Serializable]
    class Data
    {
       public List<Items> inventory;
       public Vector3 playerpos;
       public  string loadedScene;
    }
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

        playerScript = GameObject.Find("Sphere").GetComponent<PlayerBehaviour>();

        Debug.Log(SceneManager.GetActiveScene().name);

        plane = GameObject.Find("MoveToScene");

        player = GameObject.Find("Sphere");

       LoadState();

    }

    // Update is called once per frame

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

    public void LoadState()
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
    {
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
