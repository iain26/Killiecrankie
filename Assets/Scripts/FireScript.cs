using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    bool reloading = false;

    

	// Use this for initialization
	void Start () {
		
	}

    void Fire()
    {
        print(gameObject.name + " can Fire");
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(4);
        reloading = false;
        yield return 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray;
            // for debugging on PC
            if (Application.platform == RuntimePlatform.Android)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    if (!reloading)
                    {
                        reloading = true;
                        StartCoroutine(Reload());
                        Fire();
                    }
                }
            }
        }
    }
}
