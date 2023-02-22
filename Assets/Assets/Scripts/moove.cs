using UnityEngine;
using System.Collections;

public class moove : MonoBehaviour {
	public float speed;

	
	// Update is called once per frame
	void Update () {
		move ();
	}

	//movimenta planeta 
	void move(){

		transform.Translate (-Vector2.up * speed * Time.deltaTime);
		GameObject gg = GameObject.Find (this.gameObject.name);
		float posY = gg.transform.position.y;

		if(posY <=  -25.0){
			Destroy (gg);

		}

		
	}
}
