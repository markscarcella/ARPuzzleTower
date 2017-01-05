using UnityEngine;
using System.Collections;

public class TrackCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// set the forward direction of the player to match the camera
		transform.forward = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);
	}
}
