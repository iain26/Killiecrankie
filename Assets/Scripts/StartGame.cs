using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject InfoScreen;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
    }

    public void StartGameButton()
    {
        InfoScreen.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
