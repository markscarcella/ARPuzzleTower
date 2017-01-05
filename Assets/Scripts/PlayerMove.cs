using UnityEngine;
using System.Collections;
using Vuforia;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

	public int moveSpeed;
	public int jumpSpeed;
	public AudioClip jumpSound;

	public bool isGrounded;

	GameManager gameManager;
	Rigidbody rb;
	AudioSource audioSource;
	RaycastHit hit;
	float timeCounter;


	// Use this for initialization
	void Start () {

		// get the GameManager
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

		// get the Rigidbody of the player
		rb = GetComponent<Rigidbody>();

		// get the AudioSource of the player
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		// if the target loses tracking, turn off physics for the player
		if (DefaultTrackableEventHandler.isTracked)
		{
			rb.isKinematic = false;
		}
		else
		{
			rb.isKinematic = true;
		}
			
		// get the horizontal and vertical axis directions
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		// get the velocity of the player in it's local coordinates
		Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);

		// set the new velocity of the player
		rb.velocity = transform.TransformDirection(h * moveSpeed, localVelocity.y, v * moveSpeed);

		// check if jump is tapped and the player is grounded
		if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
		{
			// set the velocity of the player
			rb.velocity = transform.up * jumpSpeed;

			// play the jump sound
			audioSource.PlayOneShot(jumpSound);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			isGrounded = true;	
		}
		else if (coll.gameObject.tag == "Death")
		{
			gameManager.EndGame(false);
		}
		else
		{
			isGrounded = false;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			isGrounded = false;	
		}
		else
		{
			isGrounded = true;
		}
	}
}
