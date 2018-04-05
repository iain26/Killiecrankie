using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSceneScript : MonoBehaviour {

    public List<GameObject> JacobiteSpawn = new List<GameObject>();
    public GameObject JacobiteSquad;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;

    bool spawn1 = true;
    bool spawn2 = true;
    bool spawn3 = true;
    bool spawn4 = true;

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
        int rand = Random.Range(0, JacobiteSpawn.Count);
        while(rand == 0 && !spawn1 || rand == 1 && !spawn2 || rand == 2 && !spawn3 || rand == 3 && !spawn4 )
        {
            rand = Random.Range(0, JacobiteSpawn.Count);
        }
        newEnemy.transform.position = JacobiteSpawn[rand].transform.position;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        waited = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(r1 == null)
        {
            spawn1 = false;
        }
        if (r2 == null)
        {
            spawn2 = false;
        }
        if (r3 == null)
        {
            spawn3 = false;
        }
        if (r4 == null)
        {
            spawn4 = false;
        }
        if (waited)
        {
            waited = false;
            StartCoroutine(Wait(spawnRate));
            Spawn();
        }
	}
}
