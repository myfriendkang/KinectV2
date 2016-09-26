using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadFirstLevel : MonoBehaviour 
{
	private bool levelLoaded = false;
	
	
	void Update() 
	{
		KinectManager manager = KinectManager.Instance;
		
		if(!levelLoaded && manager && KinectManager.IsKinectInitialized())
		{
            if (Input.GetMouseButton(0)) { 
                levelLoaded = true;
                SceneManager.LoadScene(1);
            }
        }
    }
	
}
