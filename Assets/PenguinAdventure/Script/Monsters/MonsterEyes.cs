using UnityEngine;
using System.Collections;

public class MonsterEyes : MonoBehaviour {
	public float open = 1f;
	public float close = 0.3f;

	private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
		StartCoroutine (Open ());
	}

	IEnumerator Open(){
		yield return new WaitForSeconds (open);
		rend.enabled = false;
		StartCoroutine (Close ());
	}

	IEnumerator Close(){
		yield return new WaitForSeconds (close);
		rend.enabled = true;
		StartCoroutine (Open ());
	}
}
