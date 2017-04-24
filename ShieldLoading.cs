using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldLoading : MonoBehaviour {

	private bool isLoading, isShielding;
	Image loader;
	private float loadingTime;

	private AudioSource audioSource;
	private AudioClip shieldUp, shieldReady, shieldDown;

	void Awake()
	{
		audioSource = GameObject.Find("PlayerChar").GetComponent<AudioSource> ();
		shieldReady = Resources.Load<AudioClip>("Sounds/shield_ready");
		shieldUp = Resources.Load<AudioClip>("Sounds/shield_execute");
		shieldDown = Resources.Load<AudioClip>("Sounds/shield_down");
	}

	// Use this for initialization
	void Start () {
		loadingTime = 7f;
		//shieldTime = GameManager.Instance.shield;
		loader = gameObject.GetComponent<Image>();
		isLoading = false;
		isShielding = false;
	}

	// Update is called once per frame
	void Update () {

		// go from EMPTY to full
		if (isLoading) {

			// fill la fill
			loader.fillAmount += 1f / loadingTime * Time.deltaTime;
			if (loader.fillAmount == 1f) {
				audioSource.PlayOneShot(shieldReady);
				isLoading = false;
			}
		}
		if(isShielding && loader.fillAmount <= 0f) {
			audioSource.PlayOneShot(shieldDown);
				isShielding = false;
			}
		/*if(isShielding) { // go from FULL to empty
			// the Shield class itself detriments this Object's fill
			if (loader.fillAmount <= 0f) {
				isShielding = false;
			}*/
	}

	public void InitiateLoading ()
	{
		isLoading = true;
		loader.fillAmount = 0f;
	}

	public bool IsLoading ()
	{
		return isLoading;
	}

	public void InitiateShielding ()
	{
		audioSource.PlayOneShot(shieldUp);
		isShielding = true;
		loader.fillAmount = 1f;
	}

	public bool IsShielding ()
	{
		return isShielding;
	}
}
