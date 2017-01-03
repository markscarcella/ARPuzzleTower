using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Point towards middle of target
		transform.forward = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);

		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		if (h != 0)
		{
			rb.AddForce(Camera.main.transform.right * h * 10);
		}

//		if (v != 0)
//		{
//			rb.AddForce(Vector3.up * h);
//		}
//
	}
}
