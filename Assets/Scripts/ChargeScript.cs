using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    public GameObject EndPanel;
    public Text scoreText;

    private int score;

    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("Col");
        if(collision.collider.tag == "Royalist")
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        float increment = Time.deltaTime;
        Vector3 lastPos = transform.localPosition;
        transform.localPosition = new Vector3(lastPos.x - increment, lastPos.y, lastPos.z);
    }
}
