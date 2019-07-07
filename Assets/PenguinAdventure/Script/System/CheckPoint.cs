using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	PlayerController player;
	public AudioClip checkpointSound;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		if (GlobalValue.checkpoint) {
			player.transform.position = new Vector3 (transform.position.x, transform.position.y, player.transform.position.z);
			Camera.main.transform.position = new Vector3 (transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

			GameManager.Stars = GlobalValue.checkpointstars;
			GameManager.Bullets = GlobalValue.checkpointbullet;
			GameManager.Score = GlobalValue.checkpointscore;
			
		} 

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () && !GlobalValue.checkpoint) {
			GlobalValue.checkpoint = true;
			GlobalValue.isUsingJetpack = player.isUsingJetPack;
			GlobalValue.checkpointstars = GameManager.Stars;
			GlobalValue.checkpointbullet = GameManager.Bullets;
			GlobalValue.checkpointscore = GameManager.Score;
			SoundManager.PlaySfx (checkpointSound, 0.5f);

		}
	}
}
