using UnityEngine;
using System.Collections;
using System;

public class HeadTrack : MonoBehaviour {
    private KinectManager kinectManager;
    public int playerIndex = 0;
    private Vector3 screenCenterPos;

    private Vector3 headPosition;
    private bool headPosValid = false;

    public GameObject headPrefab;

    // Use this for initialization
    void Start () {
        kinectManager = KinectManager.Instance;
        //headPrefab.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (kinectManager && kinectManager.IsInitialized())
        {
            long userId = kinectManager.GetUserIdByIndex(playerIndex);

            if (kinectManager.IsUserTracked(userId) && kinectManager.IsJointTracked(userId, (int)KinectInterop.JointType.Head))
            {
                Vector3 jointHeadPos = kinectManager.GetJointPosition(userId, (int)KinectInterop.JointType.Head);
                headPosition = jointHeadPos - screenCenterPos;
                headPosValid = true;
                Debug.Log(jointHeadPos);
                headPrefab.GetComponent<Transform>().position = new Vector3(headPosition.x, headPosition.y, headPosition.z);
            }
        }


    }
}
