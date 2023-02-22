using UnityEngine;
using System.Collections;

public class destroyBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
