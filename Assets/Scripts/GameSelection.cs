using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour {

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
                    //SceneManager.LoadScene(hit.collider.gameObject.name + "Scene");   
                    SceneManager.LoadScene("WarpScene");
                }
            }
        }
	}
}
