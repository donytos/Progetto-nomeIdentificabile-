using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    Scene scene; //variable set for retrieving the current scene
    private void Awake()
    {
         scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }

    //load the main menu scene
    public void BackToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    //return to the game when the button is pressed
    public void BackToGame()
    {
        Debug.Log("entra");
        
        SceneManager.UnloadSceneAsync(scene);
     
        
    }
    private void Update()
    {
        //remove the pause menù when whe press the Escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToGame();
        }
    }
    //stopping the game from the pause
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
