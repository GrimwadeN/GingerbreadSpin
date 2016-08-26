using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    GameObject pause;
    public float scoreMultiplier = 1;

	// Use this for initialization
	void Start () {
        pause = GameObject.FindWithTag("Pause");
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1.0f)
            {
                pause.GetComponent<Text>().enabled = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                pause.GetComponent<Text>().enabled = false;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
            
        }
	}
}
