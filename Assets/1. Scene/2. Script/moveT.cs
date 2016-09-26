using UnityEngine;
using System.Collections;

public class moveT : MonoBehaviour {
    public MovieTexture mv;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Renderer>().material.mainTexture = mv;
        mv.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
