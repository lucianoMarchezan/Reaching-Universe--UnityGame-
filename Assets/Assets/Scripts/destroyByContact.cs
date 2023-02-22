using UnityEngine;
using System.Collections;

public class destroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject enemyExplosion;

	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Nao achou 'GameController' script");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
			Destroy (coll.gameObject);
			gameController.GameOver ();
		}

		if (coll.gameObject.tag == "shot") {
			
			gameController.AddScore (scoreValue);
			Destroy (coll.gameObject);
			Destroy(this.gameObject);		
			if(this.gameObject.tag=="aerolito"){
				Destroy(transform.parent.gameObject);
			}
			Instantiate(explosion, transform.position, transform.rotation);

		}
		if (coll.gameObject.tag == "shotEnemy") {

			Destroy (coll.gameObject);
			Destroy(this.gameObject);			
			Instantiate(explosion, transform.position, transform.rotation);
		
			
		}

		if (coll.gameObject.tag == "BlueEnemy1") {
			Instantiate(enemyExplosion, coll.transform.position, coll.transform.rotation);
			Destroy (coll.gameObject);


		}

		
	}
}
