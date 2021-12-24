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
    { //setting the new CineMachine to follow the player for the new Scene
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        //check the player transform and add the player at the cinemachine
        followTarget = player.transform;
        cinemachine2 = GameObject.Find("CM ClearShot1").GetComponent<CinemachineClearShot>();
        cinemachine2.LookAt = followTarget;
    }


}
