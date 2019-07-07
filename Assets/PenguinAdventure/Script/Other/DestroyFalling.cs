using UnityEngine;
using System.Collections;

public class DestroyFalling : MonoBehaviour {
	public AudioClip soundWater;
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("GAMEOVER");
			SoundManager.PlaySfx (soundWater);
			GameManager.instance.GameOver ();
			other.gameObject.SetActive (false);
		} else
			Destroy (other.gameObject);
	}
}
