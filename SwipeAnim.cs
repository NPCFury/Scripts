using UnityEngine;
using System.Collections;

public class SwipeAnim : MonoBehaviour {

	public float speed,
	             TopPos, BotPos, LeftPos, RightPos;
	public int swipeType;
	private bool doSwipe;

	// Use this for initialization
	void Start () {
		speed = 25f;
		//doSwipe = false;
		//swipeType = 0;
		TopPos = 5.71f;
		BotPos = -3.5f;
		LeftPos = -4f;
		RightPos = 4.5f;

		// TODO
		// ascertain which swipe we'll be having today
	}

	void Update () {
		// If we're supposed to swipe OR in the process of swiping
		if(doSwipe) {

			if (swipeType == 1) { // DOWNSWIPE
				transform.Translate (0, -speed * Time.deltaTime, 0);
				if (transform.position.y <= BotPos) {
					Destroy(gameObject);
					/*doSwipe = false;
					swipeType = 0;*/
				}
			} else if (swipeType == 2) { // UPSWIPE
				transform.Translate (0, -speed * Time.deltaTime, 0);
				if (transform.position.y >= TopPos) {
					Destroy(gameObject);
					/*doSwipe = false;
					swipeType = 0;*/
				}
			} else if (swipeType == 3) { // RIGHTSWIPE
				transform.Translate (0, -speed * Time.deltaTime, 0);
				if (transform.position.x >= RightPos) {
					Destroy(gameObject);
					/*doSwipe = false;
					swipeType = 0;*/
				}
			} else if (swipeType == 4) { // LEFTSWIPE
				transform.Translate (0, -speed * Time.deltaTime, 0);
				if (transform.position.x <= LeftPos) {
					Destroy(gameObject);
					/*doSwipe = false;
					swipeType = 0;*/
				}
			}
		}
	}

	public void CallSwipe(int swipeNum) {
		doSwipe = true;
		swipeType = swipeNum;
		//Debug.Log ("Swipe Type is now " + swipeNum);
		//Debug.Log ("Do Swipe is now " + doSwipe);
	}
}


