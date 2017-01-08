using UnityEngine;
using System.Collections;
using Vuforia;

public class TowerFall : MonoBehaviour {

	// Define the explosion AudioClip
	public AudioClip explosionSound;

	// Define the seconds until fall float
	public float secondsUntilFall;

	// Define the fall speed float
	public float fallSpeed;

	// Define the AudioSource
	AudioSource audioSource;

	// Define isFalling and fallTimer
	bool isFalling;
	float fallTimer;

	// Define isExploding and explosionTimer
	bool isExploding;
	float explosionTimer;

	// Use this for initialization
	void Start () {

		// get the audio source
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
		// update fall timer
		fallTimer += Time.deltaTime;

		// if enough time has passed, explode!
		if (fallTimer > secondsUntilFall)
		{
			Explode();
		}
	}

	void Explode()
	{
		// if falling, move transform down
		if (isFalling)
		{
			transform.Translate(-transform.up * fallSpeed * Time.deltaTime);
		}
		// else play explosion sound and explode
		else
		{
			audioSource.PlayOneShot(explosionSound);
			isFalling = true;
			isExploding = true;
		}

		if (isExploding)
		{
			// update explision timer
			explosionTimer += Time.deltaTime;
			// if still exploding, randomly move the tower
			if (explosionTimer < 0.5f)
			{
				transform.position = Random.onUnitSphere * 0.1f;
			}
			// else set back to start position and end explosion
			else
			{
				transform.position = Vector3.zero;
				isExploding = false;
			}
		}
	}
}
