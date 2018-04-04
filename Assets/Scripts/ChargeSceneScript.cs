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

    List<int> offLimits = new List<int>();

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
        print(JacobiteSpawn.Count);
        GameObject newEnemy = GameObject.Instantiate(JacobiteSquad);
        newEnemy.name = "JacobiteSquad";
        int rand = Random.Range(0, JacobiteSpawn.Count);
        print(offLimits[rand]);
        while(offLimits[rand] == 1)
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
            offLimits[0] = 1;
        }
        if (r2 == null)
        {
            offLimits[1] = 1;
        }
        if (r3 == null)
        {
            offLimits[2] = 1;
        }
        if (r4 == null)
        {
            offLimits[3] = 1;
        }
        if (waited)
        {
            waited = false;
            StartCoroutine(Wait(spawnRate));
            Spawn();
        }
	}
}
