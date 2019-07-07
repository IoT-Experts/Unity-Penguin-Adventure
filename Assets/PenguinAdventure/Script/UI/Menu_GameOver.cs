using UnityEngine;
using System.Collections;

public class Menu_GameOver : MonoBehaviour {
	public GameObject Next;
	// Use this for initialization
	void Start () {
		if (GlobalValue.levelPlaying >= GameManager.HighestLevel || GameManager.instance.isFinishWorld)
			Next.SetActive (false);
	}
}
