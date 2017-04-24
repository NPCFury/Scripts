using UnityEngine;
using System.Collections;

// More accurately, it would be "kill enemies on trigger enter"
// but this sounded more intuitive so whatever
public class KillEnemiesOnCollide : MonoBehaviour {

	Color objectColor;
	private AudioClip killSound;
	private AudioSource audioSource;

	void Awake ()
	{
		audioSource = GameObject.Find("PlayerChar").GetComponent<AudioSource> ();
		killSound = Resources.Load<AudioClip>("Sounds/enemy_kill");
	}

	void Start ()
	{
		
		objectColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}


	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Collided with " + other.gameObject.name);
		if (other.gameObject.CompareTag("Enemy") &&
			other.gameObject.GetComponent<SpriteRenderer>().color == objectColor) {

			GameManager.Instance.enemiesWiped++;
			audioSource.PlayOneShot(killSound);
			Destroy (other.gameObject); 
		}
	}

}
