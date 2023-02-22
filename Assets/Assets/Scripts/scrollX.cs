using UnityEngine;
using System.Collections;

public class scrollX : MonoBehaviour {

	public float speed;
	
	
	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		
		Material mat = mr.material;
		
		Vector2 offset = mat.mainTextureOffset;
		
		offset.x += speed * Time.deltaTime/10f;
		
		mat.mainTextureOffset = offset;
	}
}
