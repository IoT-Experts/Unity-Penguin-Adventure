using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_WorldChoose : MonoBehaviour {
	public GameObject Lock2;
	public GameObject Lock3;
	public Button World2;
	public Button World3;

	int WorldReached;
	// Use this for initialization
	void Start () {
		WorldReached = PlayerPrefs.GetInt ("WorldReached", 1);

		if (WorldReached > 1)
			Lock2.SetActive (false);
		else
			World2.interactable = false;
		
		if (WorldReached > 2)
			Lock3.SetActive (false);
		else
			World3.interactable = false;
		
	}
}
