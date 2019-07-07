using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	public CircleCollider2D coll1;
	public Transform CanonBody;
	public Transform FirePoint;
	public GameObject penguinHead;
	public GameObject SmokeFx;
	public AudioClip soundFire;
	public float force = 750f;
	private PlayerController player;
	private Animator anim;
	private bool isRotate = false;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotate && Input.anyKeyDown) {
			SoundManager.PlaySfx (soundFire);
			anim.SetBool ("Rotate", false);
			penguinHead.SetActive (false);
			player.transform.position = FirePoint.position;
			player.transform.rotation = FirePoint.rotation;
			player.gameObject.SetActive (true);
			player.CannonFire ();
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (force, 0));
			player.transform.rotation = Quaternion.identity;
			Instantiate (SmokeFx, FirePoint.position, Quaternion.identity);
			isRotate = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetBool ("Rotate", true);
			isRotate = true;
			player.GetComponent<Animator> ().SetTrigger ("Reset");

			StartCoroutine(DisablePlayer(0.1f));
			coll1.enabled = false;
		}
	}

	IEnumerator DisablePlayer(float time){
		yield return new WaitForSeconds (time);
		penguinHead.SetActive (true);
		player.gameObject.SetActive (false);
	}
}
