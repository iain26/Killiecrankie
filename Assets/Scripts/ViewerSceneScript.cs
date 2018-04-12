using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerSceneScript : MonoBehaviour {
    
    GameDataScript gDS;

    public GameObject r;
    public GameObject m;
    public GameObject other;

    // Use this for initialization
    void Start ()
    {
        gDS = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        switch (gDS.character)
        {
            case "Royalist":
                m.SetActive(false);
                other.SetActive(false);
                break;
            case "Musket":
                r.SetActive(false);
                other.SetActive(false);
                break;
            case "FJacobite":
                m.SetActive(false);
                r.SetActive(false);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
