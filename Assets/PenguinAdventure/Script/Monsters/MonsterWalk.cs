using UnityEngine;
using System.Collections;

public class MonsterWalk : MonoBehaviour {
	public AudioClip soundDead;
	public GameObject deadFx;
	public int scoreRewarded = 200;
	public float speed = 0.02f;
	public float dieDelay = 1f;
	[Tooltip("Hit that layer object and turn direction")]
	public LayerMask LayerTurn;

	private bool isDead = false;
	private float direction = -1f;
	private float speedWalk;
	float angle;
	// Use this for initialization
	void Start () {
		speedWalk = speed * -1;
	}

	void FixedUpdate(){
		if (!isDead) {
			transform.Translate (speedWalk, 0, 0);
			if (Physics2D.Raycast (transform.position, new Vector2 (direction, 0), 0.45f, LayerTurn)) {
				speedWalk *= -1;
				direction *= -1;
				transform.localScale = new Vector2 (transform.localScale.x * -1, 1);
			}
		}

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down,2,LayerTurn);
		if(hit){
			angle = Mathf.Atan2 (hit.normal.y, hit.normal.x) * Mathf.Rad2Deg;
			//			angle= Vector2.Angle (hit.normal, Vector2.up);
			//			Debug.DrawRay (transform.position, hit.normal * 2);
			transform.rotation = Quaternion.Euler (0, 0,angle - 90);
		}
	}

	public void Dead(){
		SoundManager.PlaySfx(soundDead);
		transform.localScale = new Vector3 (1, 0.2f, 1);
		GameManager.Score += scoreRewarded;
		StartCoroutine (WaitAndDie ());
	}

	IEnumerator WaitAndDie(){
		yield return new WaitForSeconds (dieDelay);
		Instantiate (deadFx, transform.position, Quaternion.identity);
		Destroy (gameObject);
	} 

	void OnTriggerEnter2D(Collider2D other){
		if (!isDead) {
			if (other.CompareTag ("Player")) {
				isDead = true;
				Dead ();
				//Push player up
				other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (!isDead) {
			if (other.gameObject.CompareTag ("Player")) {
				isDead = true;
				GameManager.instance.GameOver ();
			}
		}
	}
}
