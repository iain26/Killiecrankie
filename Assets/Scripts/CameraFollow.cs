using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject soldier;

    public GameObject Warning;

    public Transform GroundParent;
    public GameObject groundPrefab;
    int blockCount = 14;
    int temp = 0;

    bool obstaclePlaced = false;
    public GameObject[] obstaclePrefab;

    bool fireBullet = false;
    bool ranOnce = false;
    public Transform projectilePos;
    public GameObject projectilePrefab;

    AudioSource audioSource;
    public AudioClip bulletWarning;
    public AudioClip bulletShot;

    // Use this for initialization
    void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    public void MoveBlock()
    {
        if (blockCount < 173)
        {
            blockCount++;
            temp++;
            Destroy(GroundParent.GetChild(0).gameObject);

            GameObject groundClone = GameObject.Instantiate(groundPrefab);
            groundClone.transform.SetParent(GroundParent);
            groundClone.transform.localPosition = new Vector3(0, 0, blockCount);
            groundClone.name = blockCount.ToString();

            //if (!obstaclePlaced && blockCount < 170)
            if(temp == 10)
            {
                temp = 0;
                if(Random.Range(0, 2) < 1)
                { 
                    obstaclePlaced = true;
                    StartCoroutine(IncrementObstacleCount(5.5f));
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
                else
                {
                    StartCoroutine(IncrementProjectileCount(1));
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
        //ranOnce = true;
        // waits and displays warning
        yield return new WaitForSeconds(time - 1);
        GetComponent<AudioSource>().PlayOneShot(bulletWarning, 1);
        Warning.SetActive(true);
        // waits a second then fires
        yield return new WaitForSeconds(1);
        GameObject projectileClone = GameObject.Instantiate(projectilePrefab);
        projectileClone.transform.localPosition = projectilePos.position;
        GetComponent<AudioSource>().PlayOneShot(bulletShot, 1);
        Warning.SetActive(false);
        //fireBullet = true;
        //ranOnce = false;
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
        //if (fireBullet)
        //{
        //    Warning.SetActive(false);
        //    fireBullet = false;
        //    GameObject projectileClone = GameObject.Instantiate(projectilePrefab);
        //    projectileClone.transform.localPosition = projectilePos.position;
        //}
        //else
        //{
        //    //if (!ranOnce)
        //        //StartCoroutine(IncrementProjectileCount(/*Random.Range(4, 7)*/ 3.5f));
        //}
    }
}
