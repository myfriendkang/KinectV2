using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour
{

    Vector2 target;
    public float speed = 0.5f;

    public SpriteAnimation sp;
    bool trigger;
    public int playerIndex = 0;
    private Vector2 handPos = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        KinectManager manager = KinectManager.Instance;
        if (manager && manager.IsInitialized())
        {
            int rightHandindex = (int)KinectInterop.JointType.HandTipRight;
            if (manager.IsUserDetected())
            {
                long userId = manager.GetUserIdByIndex(playerIndex);
                if (manager.IsJointTracked(userId, rightHandindex))
                {
                    Vector3 posJointRaw = manager.GetJointKinectPosition(userId, rightHandindex);
                    /*
                    if (GameObject.Find("HandRight").activeSelf==true)
                    { 
                        Debug.Log(GameObject.Find("HandRight").GetComponent<Transform>().position);
                        target = new Vector3(GameObject.Find("HandRight").GetComponent<Transform>().position.x, GameObject.Find("HandRight").GetComponent<Transform>().position.y, GameObject.Find("HandRight").GetComponent<Transform>().position.z);
                    }
                    */
                    
                }
                if (Input.GetMouseButton(0))
                {
                    sp.PlayAnimation();
                    trigger = true;
                }
                if (trigger)
                {
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, step);
                }
            }

        }
    }
}
