using UnityEngine;
using System.Collections;

public class destroyPong : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject enemyExplosion;

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
			Destroy (coll.gameObject);
			}

		if (coll.gameObject.tag == "shotEnemy") {
			Destroy (coll.gameObject);
		}
		
		
	}
}
