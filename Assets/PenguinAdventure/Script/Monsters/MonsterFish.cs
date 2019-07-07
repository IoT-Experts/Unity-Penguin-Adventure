using UnityEngine;
using System.Collections;

public class MonsterFish : MonoBehaviour {
	public float jumpForce = 500;
	public float rotate = 60f;
	public float delayAttack = 0.35f;
	public AudioClip soundAttack;
	public AudioClip soundDead;
	public GameObject deadFx;
	public int scoreRewarded = 200;

	private bool isAttack = false;

	public void Attack(){
		transform.Rotate (Vector3.forward, -rotate);
		StartCoroutine (WaitAndAttack (delayAttack));
	}

	IEnumerator WaitAndAttack(float time){
		yield return new WaitForSeconds (time);
		SoundManager.PlaySfx (soundAttack);
		isAttack = true;
		GetComponent<Rigidbody2D> ().isKinematic = false;
		GetComponent<Rigidbody2D> ().AddRelativeForce(new Vector2(-jumpForce,0));
	}

	public void Dead(){
		SoundManager.PlaySfx(soundDead);
		GameManager.Score += scoreRewarded;
		Instantiate (deadFx, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (isAttack) {
			if (other.CompareTag ("Player")) {
				Dead ();
				//Push player up
				other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));
			}
		}
	}


	void OnCollisionEnter2D(Collision2D other){
		if (isAttack) {
			if (other.gameObject.CompareTag ("Player")) {
				GameManager.instance.GameOver ();
			}
		}
	}
}