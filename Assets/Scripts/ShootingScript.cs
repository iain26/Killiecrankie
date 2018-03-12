using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour {

    private GameObject target;

    private int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}

    public void Shoot()
    {
        if(target != null)
        {
            score += 100;
            Destroy(target);
            if(target.tag == "Dundee")
            {
                SceneManager.LoadScene("ArScene");
                score += 100;
            }
        }
    }

    void CheckRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Jacobite" || hit.collider.gameObject.tag == "Dundee")
            {
                target = hit.collider.gameObject;
            }
            else
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        CheckRay();
        scoreText.text = "Score: " + score.ToString();
	}
}
