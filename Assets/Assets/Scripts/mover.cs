using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public float shotSpeed;

	void Start (){

		GetComponent<Rigidbody2D> ().velocity = -transform.up * shotSpeed;
	}

	void Update(){
		destroyShot ();

	}

	void destroyShot(){
		GameObject gg = GameObject.Find (this.gameObject.name);
		float posY = gg.transform.position.y;
		
		if(posY >=  50.0){
			Destroy (gg);
			
		}
		
		
		
	}

}
