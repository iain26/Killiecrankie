using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float increment = Time.deltaTime * 12.5f;
        Vector3 lastPos = transform.localPosition;
        transform.localPosition = new Vector3(lastPos.x, lastPos.y, lastPos.z + increment);
    }
}
