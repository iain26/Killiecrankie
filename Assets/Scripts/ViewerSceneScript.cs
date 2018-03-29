using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerSceneScript : MonoBehaviour {
    
    GameDataScript gDS;

    public GameObject r;
    public GameObject tJ;
    public GameObject fJ;

    // Use this for initialization
    void Start ()
    {
        gDS = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        switch (gDS.character)
        {
            case "Royalist":
                tJ.SetActive(false);
                fJ.SetActive(false);
                break;
            case "TJacobite":
                r.SetActive(false);
                fJ.SetActive(false);
                break;
            case "FJacobite":
                tJ.SetActive(false);
                r.SetActive(false);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
