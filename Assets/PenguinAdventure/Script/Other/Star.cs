using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	public float speed = 10f;
	private PlayerController player;

	void Awake(){
		enabled = false;
	}

	void Start(){
		player = FindObjectOfType<PlayerController> ();
	}
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
	}

	//sent from Animation event
	public void Destroy(){
		Destroy (gameObject);
	}
}
