using UnityEngine;
using System.Collections;

public class moveEnemy1 : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireDelta;
	private float nextFire = 1.5F;
	private float myTime = 0.0F;
	private float posX;
	
	
	
	// Use this for initialization
	void Start ()
	{
		posX = transform.position.x;
		transform.Rotate (0, 0, 180);

			if (gameMenu.difficultyLevel == 3) {
			fireDelta = 1.2f;
			}
	}
	
	// Update is called once per frame
	void Update ()
	{
		move ();
		shoot ();

		
		
	}



	//movimenta planeta 



	void move(){
		
		transform.Translate (Vector2.up * speed * Time.deltaTime);

		if(transform.position.x <= posX+3){
			transform.position = new Vector3(Mathf.PingPong(Time.time, posX+2), transform.position.y, transform.position.z);
		}
		else{
			transform.position = new Vector3(-Mathf.PingPong(Time.time, posX+2), transform.position.y, transform.position.z);
		}

		if(transform.position.y <=  -25.0){
			Destroy (this.gameObject);
			
		}
	}
	
	void shoot ()
	{
		myTime = myTime + Time.deltaTime;
		
		if (myTime > nextFire) {
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			AudioSource audioClip = GetComponent<AudioSource> ();	
			audioClip.Play ();
			// create code here that animates the newProjectile        
			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
			
		
	}
}