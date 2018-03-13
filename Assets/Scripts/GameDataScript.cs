using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataScript : MonoBehaviour {

    public string sceneName;

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
	void Update () {
		
	}
}
