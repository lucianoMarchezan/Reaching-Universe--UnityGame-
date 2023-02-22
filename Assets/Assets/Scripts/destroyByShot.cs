using UnityEngine;
using System.Collections;

public class destroyByShot : MonoBehaviour {
	
	public GameObject playerExplosion;
	
	public GameObject enemyExplosion;
	private GameController gameController;
	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
			Destroy (coll.gameObject);
			gameController.GameOver ();
		}
		if (coll.gameObject.tag == "BlueEnemy1") {
			Instantiate(enemyExplosion, coll.transform.position, coll.transform.rotation);
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "aerolito") {
			Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
			Destroy (coll.gameObject);
		}
}
}
