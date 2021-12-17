using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Items item;

    private void Start()
    {
        //setting the intem selected into the scene
        ItemWorld.SpawnItemWorld(transform.position,item);
        Destroy(gameObject);
    }
}
