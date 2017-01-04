using UnityEngine;
using System.Collections;

public class TowerFall : MonoBehaviour {

	public float fallSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(transform.up * -fallSpeed * Time.deltaTime);

	}
}
