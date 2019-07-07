using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.GetComponent<Star> ().enabled = true;
		}
	}
}
