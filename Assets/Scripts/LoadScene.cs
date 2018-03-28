using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public GameObject Menu;

	// Use this for initialization
	void Start ()
    {
        if (SceneManager.GetActiveScene().name == "WarpScene")
        {
            Screen.orientation = ScreenOrientation.Portrait;
            StartCoroutine(LoadSceneDelay(GameObject.Find("GameData").GetComponent<GameDataScript>().sceneName));
        }
	}

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
        Time.timeScale = 1;
        GameObject.Find("GameData").GetComponent<GameDataScript>().ChangeSceneName("Ar");
        SceneManager.LoadScene("WarpScene");
    }

    public void LoadSniperScene()
    {
        GameObject.Find("GameData").GetComponent<GameDataScript>().ChangeSceneName("Sniper");
        SceneManager.LoadScene("WarpScene");
    }

    public void LoadLeapScene()
    {
        GameObject.Find("GameData").GetComponent<GameDataScript>().ChangeSceneName("Leap");
        SceneManager.LoadScene("WarpScene");
    }
		

	//FILTHY DESIGNER CODE BEWARE

	public void LoadMapScene()
	{
		SceneManager.LoadScene ("MapScene");
	}

	public void LoadIntro()
	{
		SceneManager.LoadScene ("IntroScene");
	}

	public void LoadGames()
	{
		SceneManager.LoadScene ("GamesScene");
	}

	public void LoadGallery()
	{
		SceneManager.LoadScene ("GalleryScene");
	}

	public void LoadViewer()
	{
		SceneManager.LoadScene ("ViewerScene");
	}

	public void Quit()
	{
		Application.Quit(); 
	}

	//END DESIGNER CODE

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadChargeScene()
    {
        GameObject.Find("GameData").GetComponent<GameDataScript>().ChangeSceneName("Charge");
        SceneManager.LoadScene("WarpScene");
    }

    public void LoadARScene()
    {
        SceneManager.LoadScene("ArScene");
    }

    IEnumerator LoadSceneDelay(string scene)
    {
        yield return new WaitForSeconds(3f);
        if (scene == "Leap" || scene == "Charge")
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
        SceneManager.LoadScene(scene + "Scene");
    }

    // Update is called once per frame
    void Update () {


	}
}
