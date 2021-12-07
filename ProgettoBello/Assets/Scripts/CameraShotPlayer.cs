using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShotPlayer : MonoBehaviour
{
    private CinemachineClearShot cinemachine2;
    public GameObject player;
    public Transform followTarget;
    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        followTarget = player.transform;
        cinemachine2 = GameObject.Find("CM ClearShot2").GetComponent<CinemachineClearShot>();
        cinemachine2.LookAt = followTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
