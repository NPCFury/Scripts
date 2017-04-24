using UnityEngine;
using System.Collections;

public class FlashHurt : MonoBehaviour {

	private bool isHurting;
	private float hurtIterator;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		hurtIterator = 2f;
		isHurting = false;
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isHurting) {
			if (hurtIterator > 0f) {
				if (sprite.color != Color.black) {
					sprite.color = Color.black;
				} else
					sprite.color = Color.white;
				hurtIterator -= .1f;
			} else {
				isHurting = false;
				hurtIterator = 2f;
			}
		}
	}

	public void StartHurt()
	{
		isHurting = true;
	}
}
