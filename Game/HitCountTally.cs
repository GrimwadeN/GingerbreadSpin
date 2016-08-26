using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitCountTally : MonoBehaviour {

    Text hitAmount;
    public GameObject counterObject;
    public float hitCounter = 0;

	// Use this for initialization
	void Start () {
        hitAmount = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        hitAmount.text = hitCounter.ToString();
	}
}
