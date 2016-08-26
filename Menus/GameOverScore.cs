using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverScore : MonoBehaviour {

    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = ((int)PlayerPrefs.GetFloat("Players Score")).ToString();
	}
}
