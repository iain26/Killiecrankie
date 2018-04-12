using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryScene : MonoBehaviour
{
    GameDataScript gDS;

    public GameObject Royalist;
    public GameObject Musket;
    //public GameObject FatJacobite;

    // Use this for initialization
    void Start()
    {
        gDS = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        Royalist.SetActive(gDS.Royalist);
        Musket.SetActive(gDS.Musket);
    }

    public void DeveloperButton()
    {
        Royalist.SetActive(true);
        Musket.SetActive(true);
        //FatJacobite.SetActive(true);
    }

   
	
	// Update is called once per frame
	void Update () {
		
	}
}
