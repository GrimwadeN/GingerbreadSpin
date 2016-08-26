using UnityEngine;
using System.Collections;

public class ClickyBlowUp : MonoBehaviour {

    GameObject scoreDisplay;
    public GameObject wheel;
    float distance;
    Vector3 centrePointOfWheel;

    [Tooltip("How much the balloon effects the score")]
    public float balloonValue = 10;
    float defaultValue;

    [HideInInspector]
    HitCountTally playerHit;

    public float multiplerValueChanger = 0.2f;
    GameObject manager;

    GameObject player;

    void Start()
    {
        scoreDisplay = GameObject.FindWithTag("Score");
        centrePointOfWheel = wheel.GetComponent<Renderer>().bounds.center;
        defaultValue = balloonValue;
        playerHit = GameObject.FindWithTag("HitCount").GetComponent<HitCountTally>();
        player = GameObject.FindGameObjectWithTag("GingerbreadMan");
        manager = GameObject.FindWithTag("GameManager");
        
    }
    
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == this.gameObject)
                {
                    // if the balloon is alive allow score to go up
                    if(GetComponent<MeshRenderer>().enabled == true)
                    { 
                        
                        playerHit.hitCounter += 1;
                        manager.GetComponent<GameStateManager>().scoreMultiplier += multiplerValueChanger;
                        balloonValue *= manager.GetComponent<GameStateManager>().scoreMultiplier;
                        
                        scoreDisplay.GetComponent<ScoreDisplay>().score += balloonValue;
                        wheel.GetComponent<SpinnyWheelSpin>().rotationSpeed += 5;
                        GetComponent<TurnMeshBackOn>().MeshSwitch(false);
                        StartCoroutine(Respawn(3));
                    }          
                    // if the mesh is disabled reduce spin speed, reduce hit counter, reduce hit multiplier
                    else if(GetComponent<MeshRenderer>().enabled == false)
                    {
                        wheel.GetComponent<SpinnyWheelSpin>().rotationSpeed -= 5;
                        playerHit.hitCounter = 1;
                        balloonValue = defaultValue;
                        manager.GetComponent<GameStateManager>().scoreMultiplier = 1;
                    }
                } 
               

                // if player doesn't hit ballon slow down the wheel spin and reduce their score and reset the hit multiplier
                if(hit.transform.tag != "Balloon")
                {
                    wheel.GetComponent<SpinnyWheelSpin>().rotationSpeed -= 5;
                    playerHit.hitCounter = 1;
                    balloonValue = defaultValue;
                    manager.GetComponent<GameStateManager>().scoreMultiplier = 1;
                }
            } 
        }
    }

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<TurnMeshBackOn>().MeshSwitch(true);
    }


}
