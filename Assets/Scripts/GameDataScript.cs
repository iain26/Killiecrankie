using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataScript : MonoBehaviour {

    public string sceneName;

    public bool SniperGame = false;
    public bool LeapGame = false;
    public bool ChargeGame = false;
    public bool Royalist = false;
    public bool ThinJacobite = false;
    public bool FatJacobite = false;

    public string objectToDisplay;
    public string character;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        GameObject[] arrayCheck = GameObject.FindGameObjectsWithTag("GameData");
        if(arrayCheck.Length > 1)
        {
            Destroy(gameObject);
        }
	}

    public void ChangeSceneName(string scene)
    {
        sceneName = scene;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ChargeScene" || SceneManager.GetActiveScene().name == "LeapScene")
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
