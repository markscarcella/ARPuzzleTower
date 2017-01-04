using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using Vuforia;

public class PlayerMove : MonoBehaviour {

	public int moveForce;
	public int jumpForce;
	public int moveSpeed;
	public int jumpSpeed;

	public bool isGrounded;
	public bool moveOnCircle;
	public bool trackCamera;

	Rigidbody rb;
	RaycastHit hit;
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

//		float h = CrossPlatformInputManager.GetAxis("Horizontal");
//		float v = CrossPlatformInputManager.GetAxis("Vertical");
//
//		if (h != 0)
//		{
//			rb.AddForce(transform.right * h * moveForce, ForceMode.Impulse);
//		}
//
//		if (v != 0)
//		{
//			rb.AddForce(transform.forward * v * moveForce, ForceMode.Impulse);
//		}
//
//		if (rb.velocity.magnitude > maxSpeed)
//		{
//			rb.velocity = rb.velocity.normalized * maxSpeed;
//		}

//		// Point towards middle of target
//		if (moveOnCircle)
//		{
//			timeCounter += CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed * 1000;
//			float x = Mathf.Cos (timeCounter);
//			float y = transform.position.y;
//			float z = Mathf.Sin (timeCounter);
//			transform.position = new Vector3 (x, y, z);
//		}
//
//		else
//		{

		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
		rb.velocity = transform.TransformDirection(h * moveSpeed, localVelocity.y, v * moveSpeed);
//
//		if (h != 0 || v != 0)
//		{
//			rb.velocity = new Vector3(h * speed, rb.velocity.y, v * speed);
//			//rb.AddForce(transform.right * h * moveForce, ForceMode.VelocityChange);
////			rb.velocity = new Vector3(transform.right.x * h * speed, rb.velocity.y, transform.right.z * h * speed);
//		}
//
//		if (v != 0)
//		{
//			//rb.AddForce(transform.forward * v * moveForce, ForceMode.VelocityChange);
//			rb.velocity = new Vector3(transform.forward.x * v * speed, rb.velocity.y, transform.forward.z * v * speed);
//		}
		//}

		if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
		{
			//rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			rb.velocity = transform.up * jumpSpeed;
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Ground")
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
