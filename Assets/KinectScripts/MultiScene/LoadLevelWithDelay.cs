using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelWithDelay : MonoBehaviour 
{

	[Tooltip("Next level number. No level is loaded, if the number is negative.")]
	public int nextLevel = 2;

	[Tooltip("Whether to check for initialized KinectManager or not.")]
	public bool validateKinectManager = true;
	private bool levelLoaded = false;


	void Start()
	{
		
		if(validateKinectManager)
		{
			KinectManager manager = KinectManager.Instance;
		}
        
	}

    void Update()
    {
        if (!levelLoaded && nextLevel >= 0)
        {
            if (validateKinectManager)
            {
                     if (Input.GetMouseButton(0))
                    {
                      levelLoaded = true;
                      SceneManager.LoadScene(nextLevel);
                   }
            }
        }
     }
}
