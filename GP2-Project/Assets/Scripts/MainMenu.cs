using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

	public void Menu()
    {
		sceneFader.FadeTo("MainMenu");
    }

	public void Instructions()
    {
		sceneFader.FadeTo("Instructions");
    }

	public void Quit ()
	{
		Debug.Log("Exiting...");
		Application.Quit();
	}

}
