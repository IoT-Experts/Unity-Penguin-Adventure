using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// This script must be place on UI button
///	Note: the name of this level object must be the same with the scene you want to load.
/// </summary>
public class Level : MonoBehaviour {
	public int level = 1;		//must be filled when you create next level
	public GameObject Locked;	
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;

	private string levelName;
	private int stars;
	private int highestLevel;

	// Use this for initialization
	void Start () {
		levelName = gameObject.name;		//get this object game
		highestLevel=PlayerPrefs.GetInt ("World" + GlobalValue.worldPlaying + "HighestLevel", 1);	//get current highest level reached
		stars = PlayerPrefs.GetInt ("World" + GlobalValue.worldPlaying + level+"stars", 0);		//get number star this level got if it completed
		CheckStars ();		//check how many star this level get and enable Star object

		if (level > highestLevel) {	
			Locked.SetActive (true);		
			GetComponent<Button> ().interactable = false;		//if this level is higher than the highest level then not allow user click on it
		} else {
			Locked.SetActive (false);		//disable Lock object to tell user this level available	
		}
	}

	//Called by button event
	public void LoadLevel(){
		GlobalValue.levelPlaying = level;		//save this level number before load scene
		Menu_HomeScreen.instance.LoadLevel (levelName);		//send scene's name to Menu_HomeScreen to load it
	}

	private void CheckStars(){
		switch (stars) {
		case 1:
			Star1.SetActive (true);
			Star2.SetActive (false);
			Star3.SetActive (false);
			break;
		case 2:
			Star1.SetActive (true);
			Star2.SetActive (true);
			Star3.SetActive (false);
			break;
		case 3:
			Star1.SetActive (true);
			Star2.SetActive (true);
			Star3.SetActive (true);
			break;
		default:
			Star1.SetActive (false);
			Star2.SetActive (false);
			Star3.SetActive (false);
			break;
		}
	}
}
