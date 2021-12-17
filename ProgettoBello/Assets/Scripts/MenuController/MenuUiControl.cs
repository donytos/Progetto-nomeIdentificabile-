using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;
using TMPro;
#endif
public class MenuUiControl : MonoBehaviour
{
    public static bool continua; // set a variable for viewing if the player pressed the continue button and load the game
    
    public GameObject firstLayer; //set a variable for the main menù layer
    public GameObject secondLayer; //set a variable for the option layer
    public bool layerVisibility; //set a variable for the visibility option between the layer
    // Start is called before the first frame update
    void Start()
    {
        firstLayer.gameObject.SetActive(true);
        secondLayer.gameObject.SetActive(false);
    }

        //call this funciton when the player click on on the button for starting a new game 
    public void NewGame()
    {
        continua = false;
        SceneManager.LoadScene(1);
    }

    //call this funciton when the player click on on the button for continue from the checkpoint
    public void LoadGame()
    {
        continua = true;
        SceneManager.LoadScene(1);
    }

    //call this funciton when the player click on on the button for exit the game
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    //call this funciton when the player click on on the button for open the option menù with the new layer
    public void Options()
    {
       
            firstLayer.gameObject.SetActive(false);
            secondLayer.gameObject.SetActive(true);
        
 

    }
    //call this funciton when the player click on on the button for returning to menù from the option layer
    public void BackToMenu()
    {
        firstLayer.gameObject.SetActive(true);
        secondLayer.gameObject.SetActive(false);
    }

    //call this funciton when the player click on on the button for going back to the main menu from the game scene
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
