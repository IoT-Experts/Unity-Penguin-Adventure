using UnityEngine;
using System.Collections;

public class MonsterIV : MonoBehaviour {
	public AudioClip soundDead;
	public GameObject deadFx;
	public int scoreRewarded = 200;
	public Transform linePoint;

	private LineRenderer line;
	void Start(){
		line = GetComponent<LineRenderer> ();
	}
	void Update(){
		line.SetPosition (0, linePoint.position);
		line.SetPosition (1, transform.position);
	}

	public void Dead(){
		SoundManager.PlaySfx(soundDead);
		GameManager.Score += scoreRewarded;
		Instantiate (deadFx, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Dead ();
			//Push player up
			other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));
		}
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GameManager.instance.GameOver ();
		}
	}
}