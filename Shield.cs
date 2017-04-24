using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// SHIELD WORKS FOR NOW pfffft
// this is an inelegant solution to a problem I can't figure out.
// even though Gamemanager's shield is always set to 7 and never touches 10,
// if I assign it to shieldDuration, it will just come out as 10. No clue why.
// so we have this wonky solution that works on the surface.
public class Shield : MonoBehaviour {

	private float shieldDuration, currentShield, shieldForce;
	private Player player;
	private GameObject loadingBar;
	private Image barFill;

	// Use this for initialization
	void Awake () {
		shieldDuration = 7f; //GameManager.Instance.shield; //tweak the hell out of this
		//Debug.Log("Shield duration will be " + shieldDuration);
		currentShield = 6f * shieldDuration;
		shieldForce = 1.5f;

		player = GameObject.Find ("PlayerChar").GetComponent<Player>();
		loadingBar = GameObject.Find ("Loading Bar Fill");
		barFill = loadingBar.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if shield is active, decrement
		if (currentShield > 0f)
		{
			//Debug.Log (currentShield);
			currentShield -= .1f;

			// kill la fill
			//Debug.Log("Decrementing loading bar");
			barFill.fillAmount -= 1.0f / shieldDuration * Time.deltaTime;

		}
		else // shield time is up
		{
			//Debug.Log ("SHIELD TIME IS UP"); 
			//start timing until the next shield loads
			loadingBar.GetComponent<ShieldLoading>().InitiateLoading();

			currentShield = 6f * shieldDuration;
			player.shielded = false;
			gameObject.SetActive (false);

		}
	}


	// find a way to not let enemies in the shield area.

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Enemy has entered shield area!");
			ForceBackEnemy (other.gameObject.GetComponent<Transform>());
		}
	}



	// YOUR MATH IS WRONG.
	// IT's BAD MATH
	void ForceBackEnemy(Transform enemy)
	{
		Vector2 newPos = Vector2.MoveTowards(gameObject.transform.position, enemy.position, 0);
		newPos.y = newPos.y * 2f;
		newPos.x = newPos.x * 2f;
		enemy.position = newPos; 
		/*Vector3 enemyPos = enemy.GetComponent<Transform>().position,
		        shieldPos = gameObject.transform.position;
		Vector2 forceDirection =  (shieldPos - enemyPos).normalized;
     
		enemy.GetComponent<Rigidbody2D>().AddForce(forceDirection * shieldForce);*/


		/*float pushPower = 0.05f;
	        Vector3 pushDir = transform.position - hit.transform.position;
	        enemy.Move(pushDir * pushPower);*/

		/*Vector3 direction = (enemy.transform.position - gameObject.transform.position).normalized;
		enemy.GetComponent<Rigidbody2D>().AddForceAtPosition(direction, gameObject.transform.position);*/

		/*Vector3 direction = (enemy.transform.position - gameObject.transform.position).normalized;
		enemy.GetComponent<Rigidbody2D>().AddForce(direction * shieldForce, ForceMode2D.Impulse);
		enemy.GetComponent<Rigidbody2D> ().velocity.Set (0f, 0f);
		//enemy.GetComponent<Rigidbody2D().velocity = Vector2.zero;
		//enemy.GetComponent<Rigidbody2D> ().mass = 0;*/



		//Vector2 direction = (enemy.position - gameObject.transform.position)/*.normalized*/ * 200;
		//enemy.position.Set(direction.x, direction.y, 0);





		/*float 	xEnemy = enemy.position.x,
				xShield = gameObject.transform.position.x,
				yEnemy = enemy.position.x,
				yShield = gameObject.transform.position.y,
				xDist, yDist;

		//you need 4 cases, one for each quadrant
		// Q1: x is +, y is +
		if (xEnemy >= 0 && yEnemy >= 0)
		{
			xDist = Mathf.Abs(xEnemy - xShield);
			yDist = Mathf.Abs(yEnemy - yShield);
		}
		// Q2: x is -, y is +
		else if (xEnemy < 0 && yEnemy >= 0)
		{
			xDist = Mathf.Max(xEnemy, xShield) - Mathf.Min(xEnemy, xShield);
			yDist = Mathf.Abs(yEnemy - yShield);
		}
		// Q3: x is -, y is -
		else if (xEnemy < 0 && yEnemy < 0)
		{
			xDist = Mathf.Max(xEnemy, xShield) - Mathf.Min(xEnemy, xShield);
			yDist = Mathf.Max(yEnemy, yShield) - Mathf.Min(yEnemy, yShield);
		}
		// Q4: x is +, y is -
		else
		{
			xDist = Mathf.Abs(xEnemy - xShield);
			yDist = Mathf.Max(yEnemy, yShield) - Mathf.Min(yEnemy, yShield);
		}*/

		//Vector3 direction = enemy.position - gameObject.transform.position;
		//enemy.position = direction;

		/*

		float xEnemy = enemy.position.x,
		xShield = gameObject.transform.position.x,
		yEnemy = enemy.position.x,
		yShield = gameObject.transform.position.y;

		Vector3 newPos = new Vector3(0, 0, 0);
		//you need 4 cases, one for each quadrant

		if (xEnemy > xShield) 											// enemy is to the right of shield
		{
			if (xEnemy < 0) { 									// if both are negative
				newPos.x = xEnemy + (xEnemy - xShield);
			}
			else if (xEnemy >= 0 && xShield < 0) 				// enemy in positive range, shield in negative
			{
				newPos.x = xEnemy + Mathf.Abs(xEnemy + xShield);
			}
			else 												// both in positive range
			{
				newPos.x = xEnemy + (xEnemy - xShield);
			}
			//newPos.x = newPos.x * shieldForce;
		}
		else 				  											// enemy is to the left of shield
		{
			if (xShield < 0) {									 // if both are negative
				newPos.x = xEnemy - (xShield - xEnemy);
			}
			else if (xShield >= 0 && xEnemy < 0) 				// shield in positive range, enemy in negative
			{
				newPos.x = xEnemy - (xShield + xEnemy);
			}
			else 												// both in positive range
			{
				newPos.x = xEnemy - (xShield - xEnemy);
			}
			//newPos.x = newPos.x * shieldForce;
		}

		if (yEnemy > yShield) 											// enemy is above shield
		{
			if (yEnemy < 0) { 									// if both are negative
				newPos.y = yEnemy + (yEnemy - yShield);
			}
			else if (yEnemy >= 0 && yShield < 0)				 // enemy in positive range, shield in negative
			{
				newPos.y = yEnemy + Mathf.Abs(yEnemy + yShield);
			}
			else 												// both in positive range
			{
				newPos.y = yEnemy + (yEnemy - yShield);
			}
			//newPos.y = newPos.y * shieldForce;
		}
		else 				  											// enemy is below shield
		{
			if (yShield < 0) { 									// if both are negative
				newPos.y = yEnemy - (yShield - yEnemy);
			}
			else if (yShield >= 0 && yEnemy < 0) 				// shield in positive range, enemy in negative
			{
				newPos.y = yEnemy - (yShield + yEnemy);
			}
			else 												// both in positive range
			{
				newPos.y = yEnemy - (yShield - yEnemy);
			}
			//newPos.y = newPos.y * shieldForce;
		}
		//newPos = newPos * shieldForce;
		enemy.position = newPos;
		//enemy.Translate((xDist * shieldForce), (yDist * shieldForce), 0);
		*/
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("Collided with " + other.gameObject.name);
		if (other.gameObject.CompareTag("Enemy")) {
				} else { // health is insufficient, game over
					// TODO trigger game over prompts
					Debug.Log ("Dead!!");
				}
			} else {
				Debug.Log ("SHIELD has BLOCKED!");
			}
		}

	}*/
}
