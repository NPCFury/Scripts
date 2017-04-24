using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System;


/// <summary>
/// This class is meant to keep track of items that scope the whole game.
/// </summary>
public class GameManager : MonoBehaviour
{
	protected GameManager() { }

	private static GameManager instance = null;
	//private static VolumeControl volumeControl = null;

	/// <summary>
	/// Stats that are not saved in PlayerPrefs.
	/// </summary>
	[NonSerialized]
	public int enemiesWiped, health = 10/*, TimedMode = 2, tutorialIsDone = 0, spiralisDone = 0*/;
	public float shield = 7f;
	// 'TimedMode' as of 7/1/16:            |       tutorialIsDone = 0, false
	// 2 = 2:00                             |       tutorialIsDone = 1, true
	// 1 = more stars worth less time       |       tutorialisDone = 3, banana
	// 0 = sandbox                          |

	// use as reference for randomized variables.
	//public int nextColor;

	/// <summary>
	/// Stats that are saved in PlayerPrefs.
	/// </summary>
	private int highScore;

	// Variable for whether the player has completed the tutorial
	//[NonSerialized]
	//public bool tutorialOver;

	/// <summary>
	/// This insures that there is only one instance of the Game Manager.
	/// </summary>
	public static GameManager Instance
	{
		get
		{
			if (GameManager.instance == null)
			{
				instance = GameObject.FindObjectOfType<GameManager>();
				DontDestroyOnLoad(instance.gameObject);
			}
			return GameManager.instance;
		}
	}



	// mess with this when you have the time
	/*
	public static VolumeControl VolumeControl
	{
		get
		{
			if (volumeControl == null)
			{
				volumeControl = GameObject.FindObjectOfType<VolumeControl>();
			}
			return volumeControl;
		}
	}
	*/


	// KEEP
	/// <summary>
	/// The player's all-time high score.
	/// Will only accept a new value if it is higher than the old.
	/// </summary>
	/*
	public int HighScore
	{
		get
		{
			return highScore;
		}
		set
		{
			if (value > highScore)
			{
				highScore = value;
				PlayerPrefs.SetInt("HighScore", highScore);
			}
		}
	}
	*/

	void Awake()
	{
		if (instance == null)
		{
			instance = GameObject.FindObjectOfType<GameManager>();
			DontDestroyOnLoad(instance.gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		//RESOLUTION
		// Switch to 780 x 780 windowed
		Screen.SetResolution(780, 780, false);
		//GetSavedStats();
	}

	/*
	public void GetSavedStats ()
	{
		bestHeight = PlayerPrefs.GetInt("BestHeight", 0);
		highScore = PlayerPrefs.GetInt("HighScore", 0);
		stardust = PlayerPrefs.GetInt("Stardust", 0);
		totalCats = PlayerPrefs.GetInt("TotalCats", 0);
		totalStars = PlayerPrefs.GetInt("TotalStars", 0);
		mostCats = PlayerPrefs.GetInt("MostCats", 0);
		mostStars = PlayerPrefs.GetInt("MostStars", 0);
		tutorialIsDone = PlayerPrefs.GetInt("tutorialIsDone", 0);
	}
	*/



	/// <summary>
	/// Ensures the game state is prepared for a new ROUND.
	/// </summary>
	public void ResetGame ()
	{
		Time.timeScale = 1;
		enemiesWiped = 0;
		/*CatScore = 0;
		HeightScore = 0;
		StarScore = 0;*/
		health = 10;
		shield = 7f;

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    		foreach (GameObject target in gameObjects) {
        	GameObject.Destroy(target);
        	}
		
	}



	public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

}