using UnityEngine;
using System.Collections;

public class MonsterV : MonoBehaviour {
	public AudioClip soundDead;
	public GameObject deadFx;
	public int scoreRewarded = 200;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			SoundManager.PlaySfx(soundDead);
			GameManager.Score += scoreRewarded;
			//Push player up
			other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));

			Instantiate (deadFx, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GameManager.instance.GameOver ();
		}
	}
}
