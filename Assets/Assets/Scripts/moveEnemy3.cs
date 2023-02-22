using UnityEngine;
using System.Collections;

 public class moveEnemy3 : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireDelta;
	private float nextFire = 1.5F;
	private float myTime = 0.0F;
	private float delta = 10.5f;
	
	
	
	// Use this for initialization
	void Start ()
	{

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
		if (transform.position.y > 18) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
			//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		} else {

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
