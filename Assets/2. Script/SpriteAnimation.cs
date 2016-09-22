using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour {

    public string _spriteName = string.Empty;
    public float _totalAnimTimeInSecond = 3f;
    public float _passedTime = 0f;
    public int _currentNumber = 0;

    public Sprite[] _sprites;
    public bool playAnim;

	// Use this for initialization
	void Start () {
        playAnim = false;
        _sprites = Resources.LoadAll<Sprite>("Bird 1");
	}
	
	// Update is called once per frame
	void Update () {
	    if(_sprites.Length > 0 && playAnim == true)
        {
            float singleAnimTime = _totalAnimTimeInSecond / _sprites.Length;
            if(_passedTime >= singleAnimTime)
            {
                _currentNumber++;
                
                if(_currentNumber>= _sprites.Length)
                {
                    _currentNumber = 0;
                   // playAnim = false;
                }
                  
                gameObject.GetComponent<SpriteRenderer>().sprite =_sprites[_currentNumber];
                _passedTime -= singleAnimTime;
            }
            _passedTime += Time.deltaTime;
        }
	}

    public void PlayAnimation()
    {
        playAnim = true;
    }

    public void StopAnimation()
    {
        playAnim = false;
    }
}
