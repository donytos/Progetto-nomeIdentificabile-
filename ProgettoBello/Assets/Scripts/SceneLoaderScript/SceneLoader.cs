using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "NewZoneScene";
    private AsyncOperation LoadLevelOperation = null;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && LoadLevelOperation == null)
        {
            LoadLevelOperation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);

        }
    }
}
