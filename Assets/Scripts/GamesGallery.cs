using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesGallery : MonoBehaviour {

    GameDataScript gDS;

    public GameObject LeapGame;
    public GameObject SnipeGame;
    public GameObject ChargeGame;

    // Use this for initialization
    void Start () {
        gDS = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        LeapGame.SetActive(gDS.LeapGame);
        SnipeGame.SetActive(gDS.SniperGame);
        ChargeGame.SetActive(gDS.ChargeGame);
    }

    public void DeveloperButton()
    {
        LeapGame.SetActive(true);
        SnipeGame.SetActive(true);
        ChargeGame.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
