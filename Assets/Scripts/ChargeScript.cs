using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    GameObject EndPanel;
    Text scoreText;

    ScoreScript scoreS;


    // Use this for initialization
    void Start () {
        scoreS = GameObject.Find("GameMgr").GetComponent<ScoreScript>();
        EndPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        scoreText = EndPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Royalist")
        {
            EndPanel.SetActive(true);
            //Time.timeScale = 0;
            scoreText.text = "Score: " + scoreS.score.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        float increment = Time.deltaTime;
        Vector3 lastPos = transform.localPosition;
        transform.localPosition = new Vector3(lastPos.x - increment, lastPos.y, lastPos.z);
    }
}
