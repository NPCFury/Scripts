using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public Transform target;
	public int chaseType, colorType, timeIterator, damage;
	public float speed, radius, minSpeed, midSpeed, maxSpeed/*, minDistance, range*/;
	//private float angle, spiralRadius, angleSpeed, radialSpeed;

	void Start()
	{
		/*spiralRadius = 1f;
		angleSpeed = 1f;
		radialSpeed = 1f;*/

		minSpeed = 1.5f;
		midSpeed = 3.5f;
		maxSpeed = 5f;
		damage = 2;
		//speed = Random.Range(minSpeed, midSpeed);
		colorType = Random.Range(0, 2);
		if(colorType == 1)
			GetComponent<SpriteRenderer>().color = Color.blue;
		else
			GetComponent<SpriteRenderer>().color = Color.red;

		radius = .5f;
		timeIterator = 0;
		chaseType = Random.Range(0, 3); //Random.Range(0, 7);
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		if (chaseType == 1) {
			speed = Random.Range(midSpeed, maxSpeed);
		}
		else speed = Random.Range(minSpeed, midSpeed);
	}

	void Update ()
	{
		if (chaseType == 0) { // DIRECT PATH TRACKING
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
		else if (chaseType == 1) { // SHORT RANGE TRACKING
			// YOOOOO okay current behavior is different than previously anticipated:
			// Will only pursue target if ALONG THE SAME AXIS.
			// Radius is irrelevant haha
			if ((Mathf.Abs (target.position.x - transform.position.x) <= radius) ||
				(Mathf.Abs (target.position.y - transform.position.y) <= radius))
			{
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
			}
		}
		/*
		else if (chaseType == 2) { // DIRECT PATH IN BURSTS
			timeIterator++;
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			if (timeIterator > 60) {
				timeIterator = 0;
			}
		}*/

		// SPIRALS
		else if (chaseType == 2) {

			//transform.LookAt(target.transform);
			//transform.Translate(transform.forward * Time.deltaTime * speed);
			//transform.rotation.Set (0, 0, 0, 0);
			transform.RotateAround(target.transform.position, Vector3.forward, 20 * Time.deltaTime);
			//transform.rotation.Set (0, 0, 0, 0);


			/*angle += Time.deltaTime * angleSpeed;

			spiralRadius -= Time.deltaTime * radialSpeed;
			 
			float x = target.position.x * spiralRadius * Mathf.Cos(Mathf.Deg2Rad*angle);
			float y = target.position.y * spiralRadius * Mathf.Sin(Mathf.Deg2Rad*angle);

			transform.position = new Vector3(x, y, 0);*/
		}
		// SPIDERS
		// FLOATING
	}
}
