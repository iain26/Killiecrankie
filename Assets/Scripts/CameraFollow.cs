using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject soldier;

    public Transform GroundParent;
    public GameObject groundPrefab;
    int blockCount = 14;

    int treeCount = 1;
    public GameObject treePrefab;

    int bulletCount = 1;
    public Transform projectilePos;
    public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
		
	}

    public void MoveBlock()
    {
        if (blockCount < 65)
        {
            blockCount++;
            Destroy(GroundParent.GetChild(0).gameObject);

            GameObject groundClone = GameObject.Instantiate(groundPrefab);
            groundClone.transform.SetParent(GroundParent);
            groundClone.transform.localPosition = new Vector3(0, 0, blockCount);
            groundClone.name = blockCount.ToString();

            if (treeCount > 0)
            {
                if (Random.Range(0, 2) < 1)
                {
                    treeCount--;
                    StartCoroutine(IncrementTreeCount( 2));
                    GameObject obstacle = GameObject.Instantiate(treePrefab);
                    obstacle.transform.SetParent(groundClone.transform);
                    obstacle.transform.localPosition = new Vector3(0, 0.837f, 0);
                }
            }
        }
    }

    IEnumerator IncrementTreeCount( int time)
    {
        yield return new WaitForSeconds(time);
        treeCount++;
        yield return 0;
    }

    IEnumerator IncrementProjectileCount(int time)
    {
        yield return new WaitForSeconds(time);
        bulletCount++;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, soldier.transform.position.z);
        if(bulletCount == 1)
        {
            if (Random.Range(0, 5) < 1)
            {
                bulletCount--;
                StartCoroutine(IncrementProjectileCount( 3));
                GameObject projectileClone = GameObject.Instantiate(projectilePrefab);
                projectileClone.transform.localPosition = projectilePos.position;
            }
        }
	}
}
