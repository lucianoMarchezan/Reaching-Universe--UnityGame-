﻿using UnityEngine;
using System.Collections;

public class aerolito : MonoBehaviour {
	public float speed;


	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed);
	}
}
