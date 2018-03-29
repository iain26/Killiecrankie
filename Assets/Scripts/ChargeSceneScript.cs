using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSceneScript : MonoBehaviour {

    public GameObject[] JacobiteSpawn;
    public GameObject JacobiteSquad;

    float spawnRate = 3;
    bool waited = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(IncreaseRate());
    }

    IEnumerator IncreaseRate()
    {
        yield return new WaitForSeconds(5);
        spawnRate = 2;
        yield return new WaitForSeconds(8);
        spawnRate = 1;
    }

    void Spawn()
    {
        GameObject newEnemy = GameObject.Instantiate(JacobiteSquad);
        newEnemy.name = "JacobiteSquad";
        int rand = Random.Range(0, 4);
        newEnemy.transform.position = JacobiteSpawn[rand].transform.position;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        waited = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (waited)
        {
            waited = false;
            StartCoroutine(Wait(spawnRate));
            Spawn();
        }
	}
}
