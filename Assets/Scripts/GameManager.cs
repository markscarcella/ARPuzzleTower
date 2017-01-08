using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManager : MonoBehaviour {

	// Define the instructions canvas
	public Canvas instructionsCanvas;

	// Define the win canvas
	public Canvas winCanvas;

	// Define the lose canvas
	public Canvas loseCanvas;

	// Define the mobile control canvas
	public Canvas mobileControlCanvas;

	// Define the isPlaying bool
	bool isPlaying;

	// Use this for initialization
	void Start () {

		// When the scene starts, turn off everything except the instructions
		if (instructionsCanvas)
		{
			instructionsCanvas.enabled = true;
		}

		if (winCanvas)
		{
			winCanvas.enabled = false;
		}

		if (loseCanvas)
		{
			loseCanvas.enabled = false;
		}

		if (mobileControlCanvas)
		{
			mobileControlCanvas.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// if the target loses tracking, pause the game
		if (DefaultTrackableEventHandler.isTracked && isPlaying)
		{
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0;
		}
	}

	public void LoadLevel(string level)
	{
		// Load the scene "level"
		SceneManager.LoadScene(level);
	}

	public void StartLevel() 
	{
		// set playing to true
		isPlaying = true;

		// enable mobile control canvas
		mobileControlCanvas.enabled = true;

		// disable instructions canvas
		instructionsCanvas.enabled = false;
	}

	public void EndGame(bool isWin)
	{
		// set playing to false
		isPlaying = false;

		// disable mobile control canvas
		mobileControlCanvas.enabled = false;

		if (isWin)
		{
			// enable win canvas
			winCanvas.enabled = true;
		}
		else 
		{
			// enable lose canvas
			loseCanvas.enabled = true;
		}
	}
}
