using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {

	public float delayFalling = 0.5f;
	public AudioClip soundBridge;

	//send from PlayerController
	public void Work(){
		SoundManager.PlaySfx (soundBridge);
		GetComponent<Animator> ().SetTrigger ("Shake");
		StartCoroutine (Falling (delayFalling));
	}

	IEnumerator Falling(float time){
		yield return new WaitForSeconds (time);
		GetComponent<Rigidbody2D> ().isKinematic = false;
		enabled = false;	//disble script
	}
}
