using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {  //open the pause menù when whe press the Escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            ReturnToMenu();
        }
    }
    //open the pause menu function
    public void ReturnToMenu()
    {
        Debug.Log("funziona");
        SceneManager.LoadSceneAsync(3);
    }
   //pause the game scene 
    void PauseGame()
    {
        Time.timeScale = 0;
    }


}
