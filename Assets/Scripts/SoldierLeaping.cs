using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierLeaping : MonoBehaviour {

    Rigidbody rb;
    Collider body;
    
    Vector3 jumpForce = new Vector3(0, 350, 0);
    bool jumped = false;

    bool crouch = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
	}

    public void Jump()
    {
        rb.AddForce(jumpForce);
        jumped = true;
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

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5);
    }

    // Update is called once per frame
    void Update ()
    {
        if (jumped && rb.velocity.y < 0 && !crouch)
        {
            rb.AddForce(0, -5, 0);
        }
    }
}
