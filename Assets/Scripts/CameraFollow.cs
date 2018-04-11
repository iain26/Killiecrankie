﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject soldier;

    public GameObject Warning;

    public Transform GroundParent;
    public GameObject groundPrefab;
    int blockCount = 14;

    bool obstaclePlaced = false;
    public GameObject[] obstaclePrefab;

    bool fireBullet = false;
    bool ranOnce = false;
    public Transform projectilePos;
    public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
		
	}

    public void MoveBlock()
    {
        if (blockCount < 173)
        {
            blockCount++;
            Destroy(GroundParent.GetChild(0).gameObject);

            GameObject groundClone = GameObject.Instantiate(groundPrefab);
            groundClone.transform.SetParent(GroundParent);
            groundClone.transform.localPosition = new Vector3(0, 0, blockCount);
            groundClone.name = blockCount.ToString();

            if (!obstaclePlaced && blockCount < 170)
            {
                if (Random.Range(0, 5) < 1)
                {
                    obstaclePlaced = true;
                    StartCoroutine(IncrementObstacleCount(2f));
                    GameObject obstacle = GameObject.Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)]);
                    obstacle.transform.SetParent(groundClone.transform);
                    obstacle.transform.localPosition = new Vector3(0, 0.837f, 0);

                    if (Random.Range(0, 3) < 1)
                    {
                        GameObject obstacle2 = GameObject.Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)]);
                        obstacle2.transform.SetParent(groundClone.transform);
                        obstacle2.transform.localPosition = new Vector3(0, 0.837f, 1);
                    }
                }
            }
        }
    }

    IEnumerator IncrementObstacleCount(float time)
    {
        yield return new WaitForSeconds(time);
        obstaclePlaced = false;
        yield return 0;
    }

    IEnumerator IncrementProjectileCount(float time)
    {
        ranOnce = true;
        yield return new WaitForSeconds(time - 1);
        Warning.SetActive(true);
        yield return new WaitForSeconds(1);
        fireBullet = true;
        ranOnce = false;
        yield return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundBlock")
        {
            MoveBlock();
        }
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, soldier.transform.position.z + 0.5f);
        if (fireBullet)
        {
            Warning.SetActive(false);
            fireBullet = false;
            GameObject projectileClone = GameObject.Instantiate(projectilePrefab);
            projectileClone.transform.localPosition = projectilePos.position;
        }
        else
        {
            if (!ranOnce)
                StartCoroutine(IncrementProjectileCount(Random.Range(4, 7)));
        }
    }
}
