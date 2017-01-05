using UnityEngine;
using System.Collections;
using Vuforia;

public class TowerFall : MonoBehaviour {

	public AudioClip explosionSound;
	public AudioClip fallingSound;
	public float secondsUntilExplosion;
	public float fallSpeed;

	AudioSource audioSource;

	float explosionTimer;
	float fallingTimer;
	bool isFalling;

	float shakeTimer;
	bool doneShaking;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (DefaultTrackableEventHandler.isTracked)
		{
			if (explosionTimer > secondsUntilExplosion)
			{
				Explode();
			}
			else
			{
				explosionTimer += Time.deltaTime;
			}
		}
	}

	void Explode()
	{
		if (!isFalling)
		{
			audioSource.PlayOneShot(explosionSound);
			isFalling = true;
		}
		else
		{
			transform.Translate(transform.up * -fallSpeed * Time.deltaTime);
			if (fallingTimer > 1.0f)
			{
				audioSource.PlayOneShot(fallingSound);
				fallingTimer = 0.0f;
			}
			fallingTimer += Time.deltaTime;
		}

		if (shakeTimer < 0.5f)
		{
			transform.position = Random.onUnitSphere * 0.1f;
			shakeTimer += Time.deltaTime;
		}
		else if (!doneShaking)
		{
			transform.position = Vector3.zero;
			doneShaking = true;
		}
	}
}
