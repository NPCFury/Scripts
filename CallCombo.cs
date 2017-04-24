using UnityEngine;
using System.Collections;
 
public class CallCombo : MonoBehaviour {

	public GameObject swiperPrefab;

	// the actual cooldown objects
	public GameObject[] cooldowns;

	// Swiper spawn points
	private Vector3[] swiperSpawnPoints;

	// All Swipe Types
	private SwipeCombo[] swipeCombos;

	private SwipeAnim swipe;
	private GameObject swiper;

	private AudioSource audioSource1, audioSource2, audioSource3;
	private AudioClip swipe1, swipe2, swipe3, swipe4, swipe5, swipe6;

	void Awake()
	{
		audioSource1 = GameObject.Find("AudioManager").GetComponent<AudioSource> ();
		audioSource2 = GameObject.Find("AudioManager1").GetComponent<AudioSource> ();
		audioSource3 = GameObject.Find("AudioManager2").GetComponent<AudioSource> ();
		swipe1 = Resources.Load<AudioClip>("Sounds/swipe_1"); // 3 and 0
		swipe2 = Resources.Load<AudioClip>("Sounds/swipe_2"); // 5 and 1
		swipe3 = Resources.Load<AudioClip>("Sounds/swipe_3"); // 7 and 2
		swipe4 = Resources.Load<AudioClip>("Sounds/swipe_4"); // 8 and 11
		swipe5 = Resources.Load<AudioClip>("Sounds/swipe_5"); // 6 and 10
		swipe6 = Resources.Load<AudioClip>("Sounds/swipe_6"); // 4 and 9
	}


	void Start()
	{
		cooldowns = new GameObject[12];
		swiperSpawnPoints = new Vector3[12];
		swipeCombos = new SwipeCombo[12];

		// makes sure we have all of the actual instances of cooldown objects
		for (int i = 0; i <= 11; i++)
		{
			cooldowns[i] = GameObject.Find ("Cooldown " + i);
			// no need to have it active if we haven't swiped yet
			cooldowns[i].SetActive (false);
		}

		// initializes all of the places where swipers will be spawned in
		// fix this to compensate for screensize haha
		swiperSpawnPoints[0] = new Vector3(-3.25f, 5.71f, 0);
		swiperSpawnPoints[1] = new Vector3(0, 5.71f, 0);
		swiperSpawnPoints[2] = new Vector3(3.41f, 5.71f, 0);
		swiperSpawnPoints[3] = new Vector3(-4.93f, 4.41f, 0);
		swiperSpawnPoints[4] = new Vector3(5.1f, 4.41f, 0);
		swiperSpawnPoints[5] = new Vector3(-4.93f, 1.01f, 0);
		swiperSpawnPoints[6] = new Vector3(5.1f, 1.01f, 0);
		swiperSpawnPoints[7] = new Vector3(-4.93f, -2.36f, 0);
		swiperSpawnPoints[8] = new Vector3(5.1f, -2.36f, 0);
		swiperSpawnPoints[9] = new Vector3(-3.25f, -4f, 0);
		swiperSpawnPoints[10] = new Vector3(0, -4f, 0);
		swiperSpawnPoints[11] = new Vector3(3.41f, -4f, 0);


		/*
		 *** SWIPE KEY COMBOS ***
		 */

		// Swipes from TOP TO BOTTOM
		swipeCombos[0] = new SwipeCombo(new string[] {"[7]", "[4]","[1]"});
		swipeCombos[1] = new SwipeCombo(new string[] {"[8]", "[5]","[2]"});
		swipeCombos[2] = new SwipeCombo(new string[] {"[9]", "[6]","[3]"});

		// Swipes from LEFT TO RIGHT
		swipeCombos[3] = new SwipeCombo(new string[] {"[7]", "[8]","[9]"});
		swipeCombos[5] = new SwipeCombo(new string[] {"[4]", "[5]","[6]"});
		swipeCombos[7] = new SwipeCombo(new string[] {"[1]", "[2]","[3]"});

		// Swipes from RIGHT TO LEFT
		swipeCombos[4] = new SwipeCombo(new string[] {"[9]", "[8]","[7]"});
		swipeCombos[6] = new SwipeCombo(new string[] {"[6]", "[5]","[4]"});
		swipeCombos[8] = new SwipeCombo(new string[] {"[3]", "[2]","[1]"});

		// Swipes from BOTTOM TO TOP
		swipeCombos[9] = new SwipeCombo(new string[] {"[1]", "[4]","[7]"});
		swipeCombos[10] = new SwipeCombo(new string[] {"[2]", "[5]","[8]"});
		swipeCombos[11] = new SwipeCombo(new string[] {"[3]", "[6]","[9]"});
	}
 
	void Update ()
	{
		// checks if at any point any combo has been executed
		if (swipeCombos[0].ComboCheck())
		{
			// if this particular swipe is not currently on cooldown,
			if (!(cooldowns[0].GetComponent<CooldownAnim>().IsCooling())) {
				//then go ahead and swipe
				ExecuteSwipe (0, 1, 1);
			}
		}
		else if (swipeCombos[1].ComboCheck())
		{
			if (!(cooldowns[1].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (1, 1, 1);
			}
		}
		else if (swipeCombos[2].ComboCheck())
		{
			if (!(cooldowns[2].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (2, 1, 1);
			}
		}
		else if (swipeCombos[3].ComboCheck())
		{
			if (!(cooldowns[3].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (3, 3, 1);
			}
		}
		else if (swipeCombos[4].ComboCheck())
		{
			if (!(cooldowns[4].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (4, 4, 2);
			}
		}
		else if (swipeCombos[5].ComboCheck())
		{
			if (!(cooldowns[5].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (5, 3, 1);
			}
		}
		else if (swipeCombos[6].ComboCheck())
		{
			if (!(cooldowns[6].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (6, 4, 2);
			}
		}
		else if (swipeCombos[7].ComboCheck())
		{
			if (!(cooldowns[7].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (7, 3, 1);
			}
		}
		else if (swipeCombos[8].ComboCheck())
		{
			if (!(cooldowns[8].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (8, 4, 2);
			}
		}
		else if (swipeCombos[9].ComboCheck())
		{
			if (!(cooldowns[9].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (9, 2, 2);
			}
		}
		else if (swipeCombos[10].ComboCheck())
		{
			if (!(cooldowns[10].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (10, 2, 2);
			}
		}
		else if (swipeCombos[11].ComboCheck())
		{
			if (!(cooldowns[11].GetComponent<CooldownAnim>().IsCooling())) {

				ExecuteSwipe (11, 2, 2);
			}
		}

	}

	// for when you refactor and make everything modular bb it's okay take your time MWAH
	/*private void CoolDownCheck ()*/

	// swipeDirection: 1 if DOWNSWIPE, 2 if UPSWIPE, 3 if RIGHTSWIPE, 4 if LEFTSWIPE
	// swipeColor: 1 if swipe will go down or right, 2 if swipe will go up or left
	private void ExecuteSwipe (int spawnPoint, int swipeDirection, int swipeColor) {


		swiper = Instantiate(swiperPrefab, swiperSpawnPoints[spawnPoint], Quaternion.identity) as GameObject;
		ColorSwiper (swiper, swipeColor);

		// rotate the swiper as needed

		//if the swiper goes from left to right
		/*if (spawnPoint == 3 || spawnPoint == 5 || spawnPoint == 7)
		{
			swiper.transform.Rotate (Vector3.forward * 90);
		}
		//if the swiper goes from right to left
		else if(spawnPoint == 4 || spawnPoint == 6 || spawnPoint == 8)
		{
			swiper.transform.Rotate (Vector3.forward * -90);
		}
		//if the swiper goes from bottom to top
		else if(spawnPoint == 9 || spawnPoint == 10 || spawnPoint == 11)
		{
			swiper.transform.Rotate (Vector3.forward * 180);
		}*/

		 switch (spawnPoint)
	        {
	        case 0:
	            audioSource1.PlayOneShot(swipe1);
	            break;
	        case 1:
	            audioSource1.PlayOneShot(swipe2);
	            break;
	        case 2:
			audioSource1.PlayOneShot(swipe3);
	            break;
	        case 3:
	            audioSource1.PlayOneShot(swipe1);
	            swiper.transform.Rotate (Vector3.forward * 90);
	            break;
	        case 4:
	            audioSource2.PlayOneShot(swipe6);
	            swiper.transform.Rotate (Vector3.forward * -90);
	            break;
	        case 5:
	            audioSource2.PlayOneShot(swipe2);
	            swiper.transform.Rotate (Vector3.forward * 90);
	            break;
	        case 6:
	            audioSource2.PlayOneShot(swipe5);
	            swiper.transform.Rotate (Vector3.forward * -90);
	            break;
	        case 7:
	            audioSource2.PlayOneShot(swipe3);
	            swiper.transform.Rotate (Vector3.forward * 90);
	            break;
	        case 8:
	            audioSource3.PlayOneShot(swipe4);
	            swiper.transform.Rotate (Vector3.forward * -90);
	            break;
	        case 9:
	            audioSource3.PlayOneShot(swipe6);
	            swiper.transform.Rotate (Vector3.forward * 180);
	            break;
	        case 10:
	            audioSource3.PlayOneShot(swipe5);
	            swiper.transform.Rotate (Vector3.forward * 180);
	            break;
	        case 11:
	            audioSource3.PlayOneShot(swipe4);
	            swiper.transform.Rotate (Vector3.forward * 180);
	            break;
	        }

		// execute combo
		swipe = swiper.GetComponent(typeof(SwipeAnim)) as SwipeAnim;
		swipe.CallSwipe(swipeDirection);

		// start this swiper's cooldown
		cooldowns[spawnPoint].SetActive (true);
		cooldowns[spawnPoint].GetComponent<CooldownAnim>().InitiateCooldown ();
	
	}

	public void ColorSwiper(GameObject swiper, int colorType)
	{
		if (colorType == 1) {
			swiper.GetComponent<SpriteRenderer> ().color = Color.red;
			swiper.GetComponent<TrailRenderer> ().material.SetColor ("_Color", new Color (1f, 0, 0, .4f));
		} else {
			swiper.GetComponent<SpriteRenderer> ().color = Color.blue;
			swiper.GetComponent<TrailRenderer> ().material.SetColor ("_Color", new Color (0, 0, 1f, .4f));
		}
	}
}