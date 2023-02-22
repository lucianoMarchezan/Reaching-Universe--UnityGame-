using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float speed;

	
	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += speed * Time.deltaTime/10f;

		mat.mainTextureOffset = offset;
	}
}
