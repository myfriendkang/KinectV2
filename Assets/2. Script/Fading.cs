using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;  //the texture that will overlay the screen. 
    public float fadeSpeed = 0.0f;    //the fading speed.

    private int drawDepth = -1000;  //the texture's order in the draw hierachy; a low number means it render on top 
    private float alpha = 1.0f;     //the texture's alpha value between 0 and 1.
    private int fadeDir = -1;       //the direction to fade : in = -1 or out = 1;
	
    void OnGUI()
    {
        //fade out/in the alpha value using direction, a speed and Time.deltatime to conver the operation to seconds.
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        Debug.Log(alpha);
        //force(clamp) the number bewteen 0 and 1 because GUI.color uses alpha values between 0 and 1.
        alpha = Mathf.Clamp01(alpha);

        //Set color of our GUI( in this case our texture). All color values remain in the same & the alpha is set to the alpha variable.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    //sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1 
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); 
    }

    //OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes.

    public void OnLevelWasLoaded()
    {
        BeginFade(-1); //Called fade in function
    }
}
