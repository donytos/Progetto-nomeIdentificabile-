using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReturnToMenu();
        }
    }
    public void ReturnToMenu()
    {
        Debug.Log("funziona");
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
 
}
