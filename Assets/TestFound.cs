using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFound : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Vea") {
			Debug.Log ("cc");
			Destroy (other.gameObject);
		}
	}
}
