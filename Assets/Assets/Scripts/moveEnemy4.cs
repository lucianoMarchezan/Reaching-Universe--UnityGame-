using UnityEngine;
using System.Collections;

public class moveEnemy4 : MonoBehaviour {

	public float speed;
	private Transform target ;
	
	
	// Use this for initialization
	void Start ()
	{
	transform.Rotate (0, 0, 180);
	target = GameObject.FindWithTag("Player").transform; //target the player

			
	}
	
	// Update is called once per frame
	void Update ()
	{
		move ();
		
		
	}
	
	
	
	//movimenta planeta 
	
	
	
	void move(){
		if (transform.position.y > 18) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
			//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		} else {
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}
	
	
	void rotate ()
	{

		
		
	}
}
