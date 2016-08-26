using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

	public void PlayMenu()
    {
        SceneManager.LoadScene("Prototype");   
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("PrototypeMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HighScore()
    {
        SceneManager.LoadScene("PrototypeHighScore");
    }
}
