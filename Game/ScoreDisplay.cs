using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    Text scoreDisplay;

    [HideInInspector]
    public float score = 0;

	// Use this for initialization
	void Start () {
        scoreDisplay = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        scoreDisplay.text = ((int)score).ToString();
	
	}
}
