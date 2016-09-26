using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAgain : MonoBehaviour {

    [Tooltip("Next level number. No level is loaded, if the number is negative.")]
    public int nextLevel = 1;

    [Tooltip("Whether to check for initialized KinectManager or not.")]
    public bool validateKinectManager = true;
    private bool levelLoaded = false;


    void Start()
    {
       
        if (validateKinectManager)
        {
            KinectManager manager = KinectManager.Instance;
        }

        StartCoroutine("FadeIN");
        Debug.Log("Kidding me?");
    }
    IEnumerator FadeIN()
    {
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(0.3f);
    }
     void Update()
    {
       
        if (!levelLoaded && nextLevel >= 0)
        {
            if (validateKinectManager)
            {
                if (Input.GetKeyUp(KeyCode.Alpha3))
                {
                    StartCoroutine("ChangeLevel");
                }
            }
        }
    }
   

    IEnumerator ChangeLevel()
    {
        levelLoaded = true;
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(nextLevel);
    }
}
