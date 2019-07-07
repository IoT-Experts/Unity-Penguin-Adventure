using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {
	public GameObject Light;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GameManager.instance.GameSuccess ();
			Light.SetActive (true);
			GetComponent<Animator> ().SetTrigger ("Close");
			other.gameObject.SetActive (false);
			enabled = false;
		}
	}
}
