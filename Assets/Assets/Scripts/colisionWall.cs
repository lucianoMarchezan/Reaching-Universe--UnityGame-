using UnityEngine;
using System.Collections;

public class colisionWall : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "shot") {
			Destroy (coll.gameObject);
			
		}
	}
}
