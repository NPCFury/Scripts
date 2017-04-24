using UnityEngine;
using System.Collections;

public class PauseOnActive : MonoBehaviour {

	// Use ethis for initialization
	void OnEnable() {
		Time.timeScale = 0;
	}

	void OnDisable()
	{
		Time.timeScale = 1;
	}
}
