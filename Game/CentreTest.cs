using UnityEngine;
using System.Collections;

public class CentreTest : MonoBehaviour {

    public GameObject wheel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = wheel.transform.position;
	}
}
