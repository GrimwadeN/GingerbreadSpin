using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour {

   public float playerLives = 3;

    ScoreDisplay score;

	// Use this for initialization
	void Start () {
        score = GameObject.FindWithTag("Score").GetComponent<ScoreDisplay>();
       
	}
	
	// Update is called once per frame
	void Update () {

        if(playerLives == 2)
        {
            GameObject.FindWithTag("Life_3").GetComponent<Image>().enabled = false;
        }
        else if(playerLives == 1)
        {
            GameObject.FindWithTag("Life_2").GetComponent<Image>().enabled = false;
        }
        else if (playerLives <= 0.1f)
        {
            GameObject.FindWithTag("Life_1").GetComponent<Image>().enabled = false;
            GameOver();
        }
	}

    void GameOver()
    {
        PlayerPrefs.SetFloat("Players Score", score.score);
        SceneManager.LoadScene("PrototypeGameOver");
    }
}
