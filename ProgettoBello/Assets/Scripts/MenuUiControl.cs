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
    public static bool continua;
    public Button options;
    public GameObject firstLayer;
    public GameObject secondLayer;
    public bool layerVisibility;
    // Start is called before the first frame update
    void Start()
    {
        firstLayer.gameObject.SetActive(true);
        secondLayer.gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void NewGame()
    {
        continua = false;
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        continua = true;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void Options()
    {
       
            firstLayer.gameObject.SetActive(false);
            secondLayer.gameObject.SetActive(true);
        
 

    }
    public void BackToMenu()
    {
        firstLayer.gameObject.SetActive(true);
        secondLayer.gameObject.SetActive(false);
    }
}
