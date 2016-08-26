using UnityEngine;
using System.Collections;

public class SpinnyWheelSpin : MonoBehaviour {

    public float rotationSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if(rotationSpeed < 10)
        {
            rotationSpeed = 10;
        }
        transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
	}
}
