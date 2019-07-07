using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {


	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	public void JumpOn(){
		player.Jump ();
	}
	public void JumpOff(){
		player.JumpOff ();
	}

	public void Attack(){
		player.Attack ();
	}
	public void SlideOn(){
		player.Slide (true);

	}
	public void SlideOff(){
		player.Slide (false);
	}
}
