using UnityEngine;
using System.Collections;
using Vuforia;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

	// Define the player move speed
	public int moveSpeed;

	// Define the player jump speed
	public int jumpSpeed;

	// Define the player jump sound
	public AudioClip jumpSound;

	// Define the rigid body
	Rigidbody rb;

	// Define the audio souce
	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		// get the Rigidbody of the player
		rb = GetComponent<Rigidbody>();

		// get the AudioSource of the player
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

		// get the horizontal and vertical axis directions
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		// get the velocity of the player in it's local coordinates
		Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);

		// set the new velocity of the player
		rb.velocity = transform.TransformDirection(h * moveSpeed, localVelocity.y, v * moveSpeed);

		// check if jump is tapped and the player is grounded
		if (CrossPlatformInputManager.GetButton("Jump") && GroundCheck())
		{
			// set the velocity of the player
			rb.velocity = transform.up * jumpSpeed;

			// play the jump sound
			audioSource.PlayOneShot(jumpSound);
		}
	}
		
	bool GroundCheck()
	{
		// Raycast downwards form the player and check if we hit something
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -transform.up, out hit, transform.localScale.y + 0.01f))
		{
			return true;
		}
		return false;
	}
}
