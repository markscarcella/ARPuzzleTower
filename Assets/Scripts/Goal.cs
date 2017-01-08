using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Define the game manager
	GameManager gameManager;

	// Use this for initialization
	void Start () {

		// get the game manager
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll)
	{
		// if the player collides with this object, end the game
		if (coll.gameObject.tag == "Player")
		{
			gameManager.EndGame(true);
		}
	}
}
