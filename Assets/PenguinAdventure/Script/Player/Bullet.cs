using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public AudioClip soundMiss;
	public AudioClip soundHit;
	public GameObject hitFx;
	public GameObject missFx;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Monster")) {
			SoundManager.PlaySfx (soundHit);
			Instantiate (hitFx, other.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		} else {
			SoundManager.PlaySfx (soundMiss);
			Instantiate (missFx, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}
}
