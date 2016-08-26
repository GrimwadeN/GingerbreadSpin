using UnityEngine;
using System.Collections;

public class HitPlayer : MonoBehaviour
{

    PlayerLives lives;

    // Use this for initialization
    void Start()
    {
        lives = GetComponent<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    lives.playerLives -= 1;
                }
            }

        }
    }
}
