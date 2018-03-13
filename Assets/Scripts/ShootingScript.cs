using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour {

    public GameObject target;

    public GameObject EndPanel;

    bool shotOnce = false;

    private int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}

    public void Shoot()
    {
        if (!shotOnce)
        {
            shotOnce = true;
            if (target != null)
            {
                score += 100;
                if (target.tag == "Leader")
                {
                    score += 200;
                }
            }
            EndPanel.SetActive(true);
            Time.timeScale = 0;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void CheckRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Royalist" || hit.collider.gameObject.tag == "Leader")
            {
                target = hit.collider.gameObject;
            }
        }
        else
        {

            target = null;
        }
    }

    // Update is called once per frame
    void Update () {
        CheckRay();
	}
}
