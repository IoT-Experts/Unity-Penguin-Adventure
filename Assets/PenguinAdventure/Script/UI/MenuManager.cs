using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public static MenuManager instance;
	public GameObject UI;
	public GameObject Controller;
	public GameObject LevelComplete;
	public GameObject GameOver;
	public GameObject GamePause;
	public GameObject Loading;

	void Awake(){
		instance = this;
		UI.SetActive (true);
		Controller.SetActive (true);
		LevelComplete.SetActive (false);
		GameOver.SetActive (false);
		GamePause.SetActive (false);
		Loading.SetActive (false);
	}

	public void Pause(){
		if (Time.timeScale == 1) {
			GamePause.SetActive (true);
			Time.timeScale = 0;
		} else {
			GamePause.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Restart(){
		GlobalValue.checkpoint = false;
		GlobalValue.isUsingJetpack = false;

		Time.timeScale = 1f;
		Loading.SetActive (true);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void MainMenu(){
		GlobalValue.checkpoint = false;
		GlobalValue.isUsingJetpack = false;

		Time.timeScale = 1f;
		Loading.SetActive (true);
		SceneManager.LoadScene ("Menu");
	}

	public void ShowGameOver(){
		StartCoroutine (ShowMenu (1, GameOver));
	}

	public void ShowLevelComplete(){
		StartCoroutine (ShowMenu (1, LevelComplete));
	}

	public void NextLevel(){
		GlobalValue.checkpoint = false;
		GlobalValue.isUsingJetpack = false;

		Loading.SetActive (true);
		GlobalValue.levelPlaying++;		//
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	IEnumerator ShowMenu(float time,GameObject Menu){
		yield return new WaitForSeconds (time);
		Menu.SetActive (true);
	}

}
