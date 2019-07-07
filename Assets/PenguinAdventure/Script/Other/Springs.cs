using UnityEngine;
using System.Collections;

public class Springs : MonoBehaviour {
	public AudioClip sound;
	public float force = 750f;

	private Animator anim;
	private PlayerController player;
	private bool isJump = false;

	bool allowPush;

	float rate = 0.3f;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		anim = GetComponent<Animator> ();
		allowPush = true;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (allowPush && !isJump && other.gameObject.CompareTag ("Player")) {
			anim.SetTrigger ("Push");
			SoundManager.PlaySfx (sound);
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, force));
			isJump = true;

			StartCoroutine (Wait (rate));
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			isJump = false;
		}
	}

	IEnumerator Wait(float time){
		allowPush = false;
		yield return new WaitForSeconds (time);
		allowPush = true;
	}
}
