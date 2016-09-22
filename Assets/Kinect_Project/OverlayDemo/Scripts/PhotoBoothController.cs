using UnityEngine;
using System.Collections;
using System.IO;

public class PhotoBoothController : MonoBehaviour
{
	[Tooltip("GUI-texture used to display the color camera feed on the scene background.")]
	public GUITexture backgroundImage;

	[Tooltip("Camera that will be used to render the background.")]
	public Camera backroundCamera;

	[Tooltip("Camera that will be used to overlay the 3D-objects over the background.")]
	public Camera foreroundCamera;

	private int maskCount = 0;
	private int currentIndex = -1;
	private int prevIndex = -1;


	void Start () 
	{
		maskCount = 0;

	}
	
	void Update () 
	{
		KinectManager manager = KinectManager.Instance;

		if (manager && manager.IsInitialized ()) 
		{
			if (backgroundImage && (backgroundImage.texture == null)) 
			{
				backgroundImage.texture = manager.GetUsersClrTex ();
			}
		}
	}
}
