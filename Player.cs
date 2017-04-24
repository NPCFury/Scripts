using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float playerSpeed; //speed character moves
	private float upBound, downBound, leftBound, rightBound; // boundaries for character movement
	private int damageDealt;
	private Transform shield;
	private GameObject loadingBar;

	public GameObject gameOverMenu;

	private AudioClip hurtSound, gameOver, restartSound;
	private AudioSource audioSource;

	// whether the player's shield is activated
	public bool shielded;

	void Awake ()
	{
		audioSource = gameObject.GetComponent<AudioSource> ();
		hurtSound = Resources.Load<AudioClip>("Sounds/ouch");
		gameOver = Resources.Load<AudioClip>("Sounds/game_over");
		restartSound = Resources.Load<AudioClip>("Sounds/new_game");
	}

	void Start()
	{
		playerSpeed = 10f;
		shielded = false;

		damageDealt = 0;
		loadingBar = GameObject.Find ("Loading Bar Fill");

		// seriously need to make these stupid numbers public members of the Game Manager, lemme tell you.
		upBound = 5f;
		downBound = -3f;
		leftBound = -4f;
		rightBound = 4f;
	}

	void Update () 
	{
		// I don't think this is the best way to do this haha
		MoveForwardCheck();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("Collided with " + other.gameObject.name);
		if (other.gameObject.CompareTag("Enemy")) {
			// if you're vulnerable
			if (!shielded) {
				
				damageDealt = other.gameObject.GetComponent<Enemy> ().damage;

				// check if you have enough health to survive the hit
				if (CheckHealth (damageDealt)) { // take the hit
					GameManager.Instance.health -= damageDealt;
					audioSource.PlayOneShot(hurtSound);
					gameObject.GetComponent<FlashHurt> ().StartHurt ();
				} else { // health is insufficient, game over
					// TODO trigger game over prompts
					audioSource.PlayOneShot(gameOver);
					gameOverMenu.SetActive (true);
				}
			} else {
				//Debug.Log ("SHIELD has BLOCKED!");
			}

			// force enemy back
		}
	}

	public void ShieldPlayer()
	{
		shield = transform.GetChild(0);
		if(!(shield.gameObject.activeSelf))
		{
			shield.gameObject.SetActive(true);
			shielded = true;
			//Debug.Log("Shield should be up, bar going down");
			loadingBar.GetComponent<ShieldLoading>().InitiateShielding ();
		}
	}


	private bool CheckHealth(int damage)
	{
		return GameManager.Instance.health > damage;
	}

	void MoveForwardCheck()
	{
		if(Input.GetKey("w") || Input.GetKey("up"))
		{
			if (transform.position.y < upBound)
				transform.Translate(0, playerSpeed * Time.deltaTime, 0);
		}
		if(Input.GetKey("s") || Input.GetKey("down"))
		{
			if (transform.position.y > downBound)
				transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
		}
		if(Input.GetKey("a") || Input.GetKey("left"))
		{
			if (transform.position.x > leftBound)
				transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
		}
		if(Input.GetKey("d") || Input.GetKey("right"))
		{
			if (transform.position.x < rightBound)
				transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
		}
		if(Input.GetKeyDown("space"))
		{
			if (!(loadingBar.GetComponent<ShieldLoading> ().IsLoading ())) {
				ShieldPlayer ();
			}
		}
	}
}
