using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string nextLevel;

	public Canvas menuCanvas;
	public Canvas winCanvas;
	public Canvas loseCanvas;

	bool isPlaying;
	public Canvas mobileControlCanvas;

	// Use this for initialization
	void Start () {
		mobileControlCanvas.enabled = false;
		menuCanvas.enabled = true;

		winCanvas.enabled = false;
		loseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(nextLevel);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void StartLevel() 
	{
		Time.timeScale = 1;
		mobileControlCanvas.enabled = true;
		menuCanvas.enabled = false;
	}

	public void EndGame(bool isWin)
	{
		Time.timeScale = 0;
		if (isWin)
		{
			mobileControlCanvas.enabled = false;
			winCanvas.enabled = true;
		}
		else 
		{
			mobileControlCanvas.enabled = false;
			loseCanvas.enabled = true;
		}
	}
}
