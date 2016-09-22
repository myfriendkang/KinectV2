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
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("go 2");
                levelLoaded = true;
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKey(KeyCode.B))
            {
                levelLoaded = true;
                SceneManager.LoadScene(0);
            }
		}
	}
	
}
