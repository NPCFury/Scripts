using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownAnim : MonoBehaviour {

	private bool isCooling;
	Image cooldownTimer;
	private float cooldownLength;

	// Use this for initialization
	void Awake () {
		cooldownLength = 3.5f;
		cooldownTimer = gameObject.GetComponent<Image>();
		isCooling = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isCooling) {

			// actually detrement the timer
			cooldownTimer.fillAmount -= 1.0f / cooldownLength * Time.deltaTime;

			if (cooldownTimer.fillAmount == 0.0f) {
				isCooling = false;
				gameObject.SetActive(false);
			}
		}
	}

	public void InitiateCooldown ()
	{
		isCooling = true;
		cooldownTimer.fillAmount = 1f;
	}

	public bool IsCooling ()
	{
		return isCooling;
	}
}
