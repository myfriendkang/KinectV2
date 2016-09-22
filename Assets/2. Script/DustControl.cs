using UnityEngine;
using System.Collections;

public class DustControl : MonoBehaviour {

    public GameObject spinePos;
    private Vector3 _defaultPos = new Vector3(0, -20, 2);
        
    // Use this for initialization
    void Start()
    {
        this.transform.position = _defaultPos;
        KinectManager manager = KinectManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        KinectManager manager = KinectManager.Instance;

        if (manager && manager.IsInitialized())
        {
            if (manager.IsUserDetected())   
            {
                this.gameObject.transform.position = new Vector3 (spinePos.GetComponent<Transform>().position.x * 10.0f, -20,2);
              //  Debug.Log("I found you!!");
            }
        }
    }
}
