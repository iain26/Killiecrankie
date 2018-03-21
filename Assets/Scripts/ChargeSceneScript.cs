using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSceneScript : MonoBehaviour {

    public GameObject[] JacobiteSpawn;
    public GameObject JacobiteSquad;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0.0f, 2f);
	}

    void Spawn()
    {
        GameObject newEnemy = GameObject.Instantiate(JacobiteSquad);
        newEnemy.name = "JacobiteSquad";
        int rand = Random.Range(0, 4);
        newEnemy.transform.position = JacobiteSpawn[rand].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
