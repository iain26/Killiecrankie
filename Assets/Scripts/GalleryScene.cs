using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryScene : MonoBehaviour
{
    GameDataScript gDS;

    public GameObject Royalist;
    public GameObject ThinJacobite;
    public GameObject FatJacobite;

    // Use this for initialization
    void Start()
    {
        gDS = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        Royalist.SetActive(gDS.Royalist);
    }

    public void DeveloperButton()
    {
        Royalist.SetActive(true);
        ThinJacobite.SetActive(true);
        FatJacobite.SetActive(true);
    }

   
	
	// Update is called once per frame
	void Update () {
		
	}
}
