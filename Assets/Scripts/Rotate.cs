﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0.0f, rotationSpeed * Time.deltaTime, 0.0f));
	}
}