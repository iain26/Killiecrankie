using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour {

    public GameObject sniperGameButton;
    public GameObject leapGameButton;

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
                    SceneManager.LoadScene("WarpScene");
                }
            }
        }


        sniperGameButton.SetActive(GameObject.Find("GameData").GetComponent<GameDataScript>().SniperGame);
        leapGameButton.SetActive(GameObject.Find("GameData").GetComponent<GameDataScript>().LeapGame);
    }
}
