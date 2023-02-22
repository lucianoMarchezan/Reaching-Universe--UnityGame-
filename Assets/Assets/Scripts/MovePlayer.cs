using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePlayer : MonoBehaviour
{
	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawnE;
	public Transform shotSpawnD;
	public float fireDelta;
	private float nextFire = 0.5F;
	private float myTime = 0.0F;
	static public bool ultra;
	private GameObject[] gameObjects;
	
	public GameObject enemyExplosion;
	// Use this for initialization
	void Start ()
	{
		ultra = false; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		move ();
		shoot ();

		
		
	}


	//movimenta jogador para a direita quando tecla eh pressioada
	void move ()
	{
		if (Input.GetAxisRaw ("Horizontal") < 0 && !Input.GetButton ("Fire2")) {
			if(Input.GetButton ("Jump")){
			transform.Translate (Vector2.right * (speed+10) * Time.deltaTime);
			}else
				transform.Translate (Vector2.right * (speed) * Time.deltaTime);
			}
		
		if (Input.GetAxisRaw ("Horizontal") > 0 && !Input.GetButton ("Fire2")) {
			if(Input.GetButton ("Jump")){
			transform.Translate (-Vector2.right * (speed+10) * Time.deltaTime);
			}else
				transform.Translate (-Vector2.right * (speed) * Time.deltaTime);
		
		}


		
	}
	
	void shoot ()
	{


		myTime = myTime + Time.deltaTime;
		
		if (Input.GetButton ("Fire1") && myTime > nextFire) {
			fireDelta = 0.35f;
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			AudioSource audioClip = GetComponent<AudioSource>();	
			audioClip.Play();
			
			// create code here that animates the newProjectile        
			
			nextFire = nextFire - myTime;
			myTime = 0.0F;

		}

		myTime = myTime + Time.deltaTime;
		
		if (Input.GetButton ("Fire2") && myTime > nextFire) {
			fireDelta = 0.10f;
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			AudioSource audioClip = GetComponent<AudioSource>();	
			audioClip.Play();
			// create code here that animates the newProjectile        
			nextFire = nextFire - myTime;
			myTime = 0.0F;	
		}

		if (Input.GetButton ("Fire3") && myTime > nextFire) {
			fireDelta = 2f;
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawnE.position, shotSpawnE.rotation);
			Instantiate (shot, shotSpawnD.position, shotSpawnD.rotation);
			AudioSource audioClip = GetComponent<AudioSource>();	
			audioClip.Play();
			// create code here that animates the newProjectile        
			nextFire = nextFire - myTime;
			myTime = 0.0F;	
		}

		if (Input.GetButton ("Fire4") && ultra) {
			ultra = false; 
			gameObjects = GameObject.FindGameObjectsWithTag ("BlueEnemy1");
			
			for(var i = 0 ; i < gameObjects.Length; i ++){
				
				Instantiate(enemyExplosion, gameObjects[i].gameObject.transform.position, 
				            gameObjects[i].gameObject.transform.rotation);
				Destroy(gameObjects[i].gameObject);
			
		}
		}



	}
		

}
