using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using Vuforia;

public class PlayerMove : MonoBehaviour {

	public int speed;
	public int jumpForce;
	public bool isGrounded;
	public bool moveOnCircle;
	public bool trackCamera;

	Rigidbody rb;
	float timeCounter;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (DefaultTrackableEventHandler.isTracked)
		{
			rb.isKinematic = false;
		}
		else
		{
			rb.isKinematic = true;
		}

		if (trackCamera)
		{
			transform.forward = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);
		}
		else
		{
			transform.LookAt(new Vector3(0.0f, transform.position.y, 0.0f));
		}

		// Point towards middle of target
		if (moveOnCircle)
		{
			timeCounter += CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed * 1000;
			float x = Mathf.Cos (timeCounter);
			float y = transform.position.y;
			float z = Mathf.Sin (timeCounter);
			transform.position = new Vector3 (x, y, z);
		}

		else
		{
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			if (h != 0)
			{
				rb.AddForce(transform.right * h * speed);
			}
			if (v != 0)
			{
				rb.AddForce(transform.forward * v * speed);
			}
		}

		if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
		{
			rb.AddForce(transform.up * jumpForce);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Jumpable")
		{
			isGrounded = true;	
		}
		else
		{
			isGrounded = false;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.tag == "Jumpable")
		{
			isGrounded = false;	
		}
		else
		{
			isGrounded = true;
		}
	}
}
