using UnityEngine;
using System.Collections;

public class moverBoss : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawnEsq;	
	public Transform shotSpawnDir;
	public float fireDelta;
	private float nextFire = 1.5F;
	private float myTime = 0.0F;
	private Vector3  startPos;
	private float delta = 10.5f;

	
	
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
			

		
		//transform.Rotate (0, 0, 180);
	}
	
	// Update is called once per frame
	void Update ()
	{
		move ();
		shoot ();
		
		
		
	}
	
	
	
	//movimenta planeta 
	
	
	
	void move(){
		if (transform.position.y > 16) {
			transform.Translate (-Vector2.up * speed * Time.deltaTime);
			//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		} else {
			Vector3 v = startPos;
			v.x += delta * Mathf.Sin (Time.time * speed);
			transform.position = new Vector3(v.x, transform.position.y, transform.position.z);
		}
	}
	
	
	void shoot ()
	{
		myTime = myTime + Time.deltaTime;
		
		if (myTime > nextFire) {
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			Instantiate (shot, shotSpawnEsq.position, shotSpawn.rotation);
			Instantiate (shot, shotSpawnDir.position, shotSpawn.rotation);
			AudioSource audioClip = GetComponent<AudioSource> ();	
			audioClip.Play ();
			// create code here that animates the newProjectile        
			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
		
		
	}
}
