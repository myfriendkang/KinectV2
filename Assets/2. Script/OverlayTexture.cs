using UnityEngine;
using System.Collections;


public class OverlayTexture : MonoBehaviour {
    [Tooltip("GUI-Texture used to display the color camera feed on the scene background")]
    public GUITexture backgroundImage;

    [Tooltip("index of player. 0 means 1st player. -1 means nobody")]
    public int playerIndex = 0;

    [Tooltip("Textures")]
    public Texture overlayImage;
    public Transform overlayObject;

    public KinectInterop.JointType trackedJoint; //= KinectInterop.JointType.Head;

    [Tooltip("smooth factor for image movement")]
    public float smoothFactor = 10f;
    private Vector2 imagePos = Vector2.zero;
    private int headCount = -200;
    private bool isShow = false;

    private Quaternion initialRotation = Quaternion.identity;
    private bool objFlipped = false;

    void Start()
    {
        if (overlayObject)
        {
            initialRotation = overlayObject.rotation;
            objFlipped = (Vector3.Dot(overlayObject.forward, Vector3.forward) < 0);
            overlayObject.rotation = Quaternion.identity;
        }
    }
     
	void Update () {
        KinectManager manager = KinectManager.Instance;
        
        if(manager && manager.IsInitialized())
        {
            if(backgroundImage && (backgroundImage.texture == null))
            {
                backgroundImage.texture = manager.GetUsersClrTex();
            }
            int indexOfPart = (int)trackedJoint;
           
            //int headIndex = (int)KinectInterop.JointType.Head;
            headCount = indexOfPart;
            if (manager.IsUserDetected())
            {
                long userId = manager.GetUserIdByIndex(playerIndex);

                if(manager.IsJointTracked(userId, indexOfPart))
                {
                    Vector3 posJoint = manager.GetJointPosColorOverlay(userId, indexOfPart, Camera.main, Camera.main.pixelRect);
                  
                    Vector3 posJointRaw = manager.GetJointKinectPosition(userId, indexOfPart);
                    if (posJointRaw != Vector3.zero) //
                    {
                        Vector2 posDepth = manager.MapSpacePointToDepthCoords(posJointRaw); //
                        ushort depthValue = manager.GetDepthForPixel((int)posDepth.x, (int)posDepth.y);

                        if(posDepth != Vector2.zero && depthValue > 0)
                        {
                            Vector2 posColor = manager.MapDepthPointToColorCoords(posDepth, depthValue);
                            if(!float.IsInfinity(posColor.x) && !float.IsInfinity(posColor.y))
                            {
                                float colorWidth = manager.GetColorImageWidth();
                                float colorOfsX = 0;

                                PortraitBackground portraitBack = PortraitBackground.Instance;
                                if(portraitBack && portraitBack.enabled)
                                {
                                    colorWidth = manager.GetColorImageHeight() * manager.GetColorImageHeight() / manager.GetColorImageWidth();
                                    colorOfsX = (manager.GetColorImageWidth() - colorWidth) / 2f;
                                }

                                float xScaled = (posColor.x - colorOfsX) / colorWidth;
                                float yScaled = posColor.y / manager.GetColorImageHeight();

                                imagePos = Vector2.Lerp(imagePos, new Vector2(xScaled, 1f - yScaled), smoothFactor * Time.deltaTime);
                                if (Input.GetKeyDown(KeyCode.S))
                                {
                                    isShow = true;
                                   
                                }
                                else if (Input.GetKeyDown(KeyCode.D))
                                {
                                    isShow = false;
                                }
                                
                            }
                        }

                    }
                }
            }
        }
    }

    public Vector2 GetHeadPos()
    {
        return imagePos;
    }
   
    
    void OnGUI()
    {
        Texture texture = null;
        if(headCount != -200)
        {
            texture = overlayImage;
        }
        
        if((imagePos != Vector2.zero) && (texture!= null))
        {
            Rect rectTexture = new Rect((imagePos.x * Screen.width) - (texture.width / 2),  
                                        ((1f - imagePos.y) * Screen.height) - (texture.height / 2),
                                        texture.width, texture.height);
            if (isShow)
            {
                GUI.DrawTexture(rectTexture, texture);
            }
        }
    }
    

}
