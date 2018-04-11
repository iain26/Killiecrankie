using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float increment = Time.deltaTime;
        Vector3 lastPos = transform.localPosition;
        transform.localPosition = new Vector3(lastPos.x - increment, lastPos.y, lastPos.z);
        Debug.Log("its brittany bitch");
	}
}
