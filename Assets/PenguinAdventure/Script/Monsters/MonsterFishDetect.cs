using UnityEngine;
using System.Collections;

public class MonsterFishDetect : MonoBehaviour {
	public MonsterFish monster;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			monster.Attack ();
			Destroy (gameObject);
		}
	}
}
