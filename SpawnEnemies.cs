using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public float spawnCooldown;
	private float timeUntilSpawn;
	public GameObject enemyPrefab; // this is the prefab of the enemy we'll be spawning
	float upBound, downBound, leftBound, rightBound;

	// Use this for initialization
	void Start () {
		
		spawnCooldown = 3f;
		timeUntilSpawn = 1f;
		upBound = 5f;
		downBound = -3f;
		leftBound = -4f;
		rightBound = 4f;
	}

	 public void Update()
	 {
	     timeUntilSpawn -= Time.deltaTime;
	     if(timeUntilSpawn <= 0f)
	     {
	         // Call enemy spawn
	         Spawn();
	         // Reset for next spawn
	         timeUntilSpawn = spawnCooldown;
	     }
	 }

	private bool SpawnOnPlayer(Vector3 pos)
	{
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
		if (Mathf.Abs ((pos.x - player.position.x)) <= 1 || Mathf.Abs ((pos.y - player.position.y)) <= 1) {
			return true;
		}
		else return false;
	}

	// actually spawn the enemy
	 public void Spawn()
	 {
		Vector3 newPos;
		do {
			newPos = new Vector3 (Random.Range (leftBound, rightBound), Random.Range (downBound, upBound), 0);
		} while(SpawnOnPlayer(newPos)); // makes sure no enemies spawn within a certain radius of the player

		GameObject enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
	 }
}
