using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadFirstLevel : MonoBehaviour 
{
	private bool levelLoaded = false;
    private bool isFirst = true;
    public bool validateKinectManager = true;

    void Start()
    {
        if (validateKinectManager)
        {
            KinectManager manager = KinectManager.Instance;
        }
    }

    void Update()
    {
        if (validateKinectManager)
        {
            KinectManager manager = KinectManager.Instance;

            if (!levelLoaded && manager && KinectManager.IsKinectInitialized())
            {
                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    levelLoaded = true;
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
