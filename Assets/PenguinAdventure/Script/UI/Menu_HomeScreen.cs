using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_HomeScreen : MonoBehaviour {
	public static Menu_HomeScreen instance;
	public GameObject MainMenu;
	public GameObject WorldChoose;
	public GameObject World1;
	public GameObject World2;
	public GameObject World3;
	public GameObject Loading;

	public string faceBookLink = "your facebook link";
	public string twitterLink = "your twitter link";
	public string moreGameLink = "more game link";

	int WorldReached;

	void Awake(){
		instance = this;

		MainMenu.SetActive (true);
		WorldChoose.SetActive (false);
		World1.SetActive (false);
		World2.SetActive (false);
		World3.SetActive (false);
		Loading.SetActive (false);
	}

	void Start(){
		WorldReached = PlayerPrefs.GetInt ("WorldReached", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}

	public void Play(){
		MainMenu.SetActive (false);
		WorldChoose.SetActive (true);
	}

	public void Facebook(){
		Application.OpenURL (faceBookLink);
	}

	public void Twitter(){
		Application.OpenURL (twitterLink);
	}

	public void MoreGame(){
		Application.OpenURL (moreGameLink);
	}

	public void Menu(){
		MainMenu.SetActive (true);
		WorldChoose.SetActive (false);
		World1.SetActive (false);
		World2.SetActive (false);	//turn this on if you make world 2
		World3.SetActive (false);	//turn this on if you make world 3
	}

	public void LoadLevel(string nameScene){
		Loading.SetActive (true);
		SceneManager.LoadScene (nameScene);
	}

	public void ShowWorld1(){
		GlobalValue.worldPlaying = 1;
		World1.SetActive (true);
		WorldChoose.SetActive (false);
	}

	public void ShowWorld2(){
		if (WorldReached < 2)
			return;
		
		GlobalValue.worldPlaying = 2;
		World2.SetActive (true);
		WorldChoose.SetActive (false);
	}

	public void ShowWorld3(){
		if (WorldReached < 3)
			return;
		
		GlobalValue.worldPlaying = 3;
		World3.SetActive (true);
		WorldChoose.SetActive (false);
	}
}
