using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitDestroy());
	}

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        float increment = Time.deltaTime * 10.5f;
        Vector3 lastPos = transform.localPosition;
        transform.localPosition = new Vector3(lastPos.x, lastPos.y, lastPos.z + increment);
    }
}
