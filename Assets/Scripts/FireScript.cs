using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    bool reloading = false;

    bool firing = false;

    public Material ReadyM;
    public Material ReloadM;

    public ScoreScript scoreS;


    // Use this for initialization
    void Start () {
		
	}

    void Fire(GameObject target)
    {
        scoreS.score += 100;
        Destroy(target);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(4);
        GetComponent<Renderer>().material = ReadyM;
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
                    if(!reloading)
                    firing = true;
                }
            }
        }
        if ((Input.GetMouseButtonUp(0) && firing)|| (Input.touchCount > 0 && firing))
        {
            GetComponent<Renderer>().material = ReloadM;
            firing = false;
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
                if (hit.collider.gameObject.tag == "Jacobite")
                {
                    if (!reloading)
                    {
                        reloading = true;
                        StartCoroutine(Reload());
                        Fire(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
