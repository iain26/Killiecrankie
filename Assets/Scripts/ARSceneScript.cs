using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string model = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>().objectToDisplay;
        switch (model)
        {
            case "Royalist":
                GameObject.Find("Models").transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Leap":
                GameObject.Find("Models").transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "Sniper":
                GameObject.Find("Models").transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Charge":
                GameObject.Find("Models").transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "TJacobite":
                GameObject.Find("Models").transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "FJacobite":
                GameObject.Find("Models").transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
