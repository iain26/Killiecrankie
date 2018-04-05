using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public LineRenderer line;
    Vector3 lineEndPos;
    public GameObject bang;

    bool reloading = false;

    bool firing = false;

    Touch phoneTouch;

    public Material ReadyM;
    public Material ReloadM;

    public ScoreScript scoreS;

    List<Vector2> TouchPositions = new List<Vector2>();

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
        transform.localPosition = new Vector3(transform.localPosition.x, 0.25f, transform.localPosition.z);
        reloading = false;
        yield return 0;
    }

    void Rays()
    {
        if (Input.GetMouseButtonDown(0) && !reloading|| Input.touchCount > 0 && !reloading)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                phoneTouch = Input.GetTouch(0);
            }
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
                        line.enabled = true;
                        line.SetPosition(0, gameObject.transform.position);
                        firing = true;
                }
            }
        }


        if ((Input.GetMouseButtonUp(0) && firing && Application.platform != RuntimePlatform.Android) || (Input.touchCount == 0 && firing && Application.platform == RuntimePlatform.Android))
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<Animator>().Play("Fire");
            }
            GetComponent<Renderer>().material = ReloadM;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.05f, transform.localPosition.z);
            firing = false;
            RaycastHit hit;
            Ray ray;
            // for debugging on PC

            if (Application.platform == RuntimePlatform.Android)
            {
                ray = Camera.main.ScreenPointToRay(phoneTouch.position);
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
                        Fire(hit.collider.gameObject);
                    }
                }
            }
            line.enabled = false;
            GameObject gunMuzzle = Instantiate(bang);
            gunMuzzle.transform.position = transform.position;
            StartCoroutine(Reload());
        }
    }
	
	// Update is called once per frame
	void Update () {
        Rays();
        if(line.enabled == true)
        {
            line.SetPosition(1, lineEndPos);
            RaycastHit hit;
            Ray ray;
            // for debugging on PC

            if (Application.platform == RuntimePlatform.Android)
            {
                ray = Camera.main.ScreenPointToRay(phoneTouch.position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
            if (Physics.Raycast(ray, out hit))
            {
                lineEndPos = hit.point;
            }
            lineEndPos.y = 0.25f;
            line.SetPosition(1, lineEndPos);
        }
        if (firing)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                TouchPositions.Add(Input.GetTouch(0).position);
            }
        }
    }
}
