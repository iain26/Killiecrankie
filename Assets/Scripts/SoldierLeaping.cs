using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierLeaping : MonoBehaviour {

    Rigidbody rb;
    Collider body;

    public CameraFollow cam;

    public GameObject EndPanel;
    public Text Result;

    Vector3 jumpForce = new Vector3(0, 450, 0);
    bool jumped = false;

    bool crouch = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
	}

    public void Jump()
    {
        if (!jumped)
        {
            rb.AddForce(jumpForce);
            jumped = true;
        }
    }

    public void Crouch()
    {
        if (!crouch)
        {
            crouch = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.position = new Vector3(transform.position.x, 1.01f, transform.position.z);
        }
        else
        {
            crouch = false;
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "GroundBlock")
        {
            jumped = false;
        }
        if (collision.collider.tag == "EndBlock")
        {
            EndPanel.SetActive(true);
            Result.text = "You Made the Leap";
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallZone")
        {
            EndPanel.SetActive(true);
            Result.text = "You fell to your Death";
            Time.timeScale = 0;
        }
        if (other.tag == "Obstacle")
        {
            EndPanel.SetActive(true);
            Result.text = "You tripped and were savagely beaten";
            Time.timeScale = 0;
        }
        if (other.tag == "Projectile")
        {
            EndPanel.SetActive(true);
            Result.text = "You were shot";
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5);
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.localPosition.y > 2.5f)
        {
            rb.AddForce(0, -10, 0);
        }
    }
}
