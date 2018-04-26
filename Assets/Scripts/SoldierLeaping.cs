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

    Vector3 jumpForce = new Vector3(0, 350, 0);
    bool jumped = false;

    float forwardForce = 5;

    bool waited = true;

    bool crouch = false;
    public Collider crouchCollider;
    public Collider runCollider;

    Animator anim;

	AudioSource audioSource;
	public AudioClip bulletHit;
	public AudioClip death;
	public AudioClip obstacleHit;
	public AudioClip jump;
	public AudioClip success;

    bool dead = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        waited = true;
    }

    public void Jump()
    {
        if (!jumped && waited)
        {
            waited = false;
            StartCoroutine(Wait());
            jumped = true;
            if (crouch)
            {
                jumpForce = new Vector3(0, 225f, 0);
            }
            anim.SetBool("Jump", true);
            rb.AddForce(jumpForce);
			GetComponent<AudioSource> ().PlayOneShot (jump, 1);
            jumpForce = new Vector3(0, 350, 0);
        }
    }

    public void Crouch()
    {
        if (!crouch)
        {
            //if (!jumped)
            {
                crouch = true;
                anim.SetBool("Crouch", true);
                crouchCollider.enabled = true;
                runCollider.enabled = false;
            }
        }
        else
        {
            anim.SetBool("Crouch", false);
            crouch = false;
            runCollider.enabled = true;
            crouchCollider.enabled = false;
        }
    }

    IEnumerator Fall()
    {
        forwardForce = 0;
        anim.SetBool("Fall", true);
        yield return new WaitForSeconds(2.533f);
        Time.timeScale = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "GroundBlock")
        {
            jumped = false;
            anim.SetBool("Jump", false);
        }
        if (collision.collider.tag == "EndBlock")
        {
            EndPanel.SetActive(true);
            Result.text = "You Made the Leap";
			GetComponent<AudioSource> ().PlayOneShot (success, 1);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!dead)
        {
            if (other.tag == "Edge")
            {
                forwardForce = 0;
            }
            if (other.tag == "FallZone")
            {
                EndPanel.SetActive(true);
                Result.text = "You fell to your Death";
                Time.timeScale = 0;
                dead = true;
            }
            if (other.tag == "Obstacle")
            {
                EndPanel.SetActive(true);
                Result.text = "You tripped and were savagely beaten";
				GetComponent<AudioSource> ().PlayOneShot (obstacleHit, 1);
				GetComponent<AudioSource> ().PlayOneShot (death, 1);
                StartCoroutine(Fall());
                dead = true;
            }
            if (other.tag == "Projectile")
            {
                EndPanel.SetActive(true);
                Result.text = "You were shot";
				GetComponent<AudioSource> ().PlayOneShot (bulletHit, 1);
				GetComponent<AudioSource> ().PlayOneShot (death, 1);
                StartCoroutine(Fall());
                dead = true;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardForce);
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
