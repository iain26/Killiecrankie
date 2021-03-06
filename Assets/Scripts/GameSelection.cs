﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour {

    public GameObject sniperGameButton;
    public GameObject leapGameButton;
    public GameObject chargeGameButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
        {
            RaycastHit hit;
            Ray ray;
            // for debugging on PC
            if (Application.platform == RuntimePlatform.Android)
            {
                 ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "LevelTransisition")
                {
                    GameObject.Find("GameData").GetComponent<GameDataScript>().ChangeSceneName(hit.collider.gameObject.name);
                    if(hit.collider.gameObject.name == "Sniper")
                    {
                        GameObject.Find("GameData").GetComponent<GameDataScript>().SniperGame = true;
                    }
                    if (hit.collider.gameObject.name == "Leap")
                    {
                        GameObject.Find("GameData").GetComponent<GameDataScript>().LeapGame = true;
                    }
                    if (hit.collider.gameObject.name == "Charge")
                    {
                        GameObject.Find("GameData").GetComponent<GameDataScript>().ChargeGame = true;
                    }
                    if (hit.collider.gameObject.name == "Royalist")
                    {
                        GameObject.Find("GameData").GetComponent<GameDataScript>().character = "Royalist";
                        GameObject.Find("GameData").GetComponent<GameDataScript>().Royalist = true;
                        SceneManager.LoadScene("ViewerScene");
                    }
                    //if (hit.collider.gameObject.name == "TJacobite")
                    //{
                    //    GameObject.Find("GameData").GetComponent<GameDataScript>().character = "TJacobite";
                    //    GameObject.Find("GameData").GetComponent<GameDataScript>().ThinJacobite = true;
                    //    SceneManager.LoadScene("ViewerScene");
                    //}
                    //if (hit.collider.gameObject.name == "FJacoBite")
                    //{
                    //    GameObject.Find("GameData").GetComponent<GameDataScript>().character = "FJacobite";
                    //    GameObject.Find("GameData").GetComponent<GameDataScript>().FatJacobite = true;
                    //    SceneManager.LoadScene("ViewerScene");
                    //}
                    SceneManager.LoadScene("WarpScene");
                }
            }
        }
    }
}
