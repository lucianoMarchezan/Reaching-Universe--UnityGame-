using UnityEngine;
using System.Collections;

public class bossLife : MonoBehaviour {

	public GameObject explosion;
	
	public GameObject explosionPong;
	
	private int scoreValue ;
	private GameController gameController;
	private int bossLifeScore;
	private int bossInitialLife;
	private Color colorDefalut ;
	private float elapsedTime;
	private bool shieldUp;
	private Transform meeple;
	
	float elapsedTime2;
	void Start ()
	{	
		meeple = this.gameObject.transform.GetChild(3);
		shieldUp = true; 
		colorDefalut = GetComponent<SpriteRenderer>().color;
		scoreValue = 10000;
		
		if (gameMenu.difficultyLevel == 1) {

			bossLifeScore = 5000;
			
		}
		if (gameMenu.difficultyLevel == 2) {
			bossLifeScore = 7500;
			
			
		}
		if (gameMenu.difficultyLevel == 3) {
			bossLifeScore = 10000;
		}
		
		bossInitialLife = bossLifeScore;

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

		if (coll.gameObject.tag == "Pong" && shieldUp) {
			Destroy (coll.gameObject);
			Instantiate(explosionPong, transform.position, transform.rotation);
			shieldUp = false;
			meeple.gameObject.SetActive(false);

		}

		if (coll.gameObject.tag == "shot") {
			Destroy (coll.gameObject);


			if(!shieldUp){
				bossLifeScore-=25;
				
				GetComponent<SpriteRenderer>().color = Color.red;
				
			}
			if(bossLifeScore<=0){

			gameController.AddScore (scoreValue);
			
			Destroy(this.gameObject);		
			Instantiate(explosion, transform.position, transform.rotation);
				
				Application.LoadLevel(2);
			}
			

		}
	}
		
		void Update()
		{
			elapsedTime += Time.deltaTime;
			
			if (elapsedTime >= 1)
			{
				elapsedTime -= 1;
				// insert logic for changing color below:
			GetComponent<SpriteRenderer>().color = colorDefalut;
			}



		if(!shieldUp){
			elapsedTime2+= Time.deltaTime;
		

		if(elapsedTime2>= 5){
			shieldUp = true;
			meeple.gameObject.SetActive(true);
			elapsedTime2 =0;
		}
		
		}
			

		}
		
		
	
}
