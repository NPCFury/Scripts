using UnityEngine;
using System.Collections;

public class OpacityJitter : MonoBehaviour {

	float maxOpacity, minOpacity, jitterAmount, opacityIterator;
	private SpriteRenderer sprite;

	// true when we're getting brighter
	private bool brighter;

	// Use this for initialization
	void Start () {
		
		maxOpacity = .3f;
		minOpacity = .05f;
		jitterAmount = .001f;

		opacityIterator = Random.Range(minOpacity, maxOpacity);
		brighter = (Random.Range (0, 2) == 1);

		sprite = gameObject.GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (opacityIterator);
		if (brighter)
		{
			if (opacityIterator <= maxOpacity) {
				opacityIterator += jitterAmount;
			} else
				brighter = false;
		}
		else
		{
			if (opacityIterator >= minOpacity) {
				opacityIterator -= jitterAmount;
			} else
				brighter = true;
		}

		sprite.color = new Color(1f, 1f, 1f, opacityIterator);
	
	}
}
