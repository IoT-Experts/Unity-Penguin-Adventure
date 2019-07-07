using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Handle Level Complete UI of Menu object
/// </summary>
public class Menu_Complete : MonoBehaviour {
	public GameObject Menu;
	public GameObject Restart;
	public GameObject Next;
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;

	public Text Score;
	public Text Best;

	private int scoreRunning;
	private int score = 0;
	private bool finishCounting = false;

	void Awake(){
		Menu.SetActive (false);
		Restart.SetActive (false);
		Next.SetActive (false);
		Star1.SetActive (false);
		Star2.SetActive (false);
		Star3.SetActive (false);
	}
		
	void Start () {
		Best.text = GameManager.Best + "";
		scoreRunning = GameManager.Score / 90;		//count in 1.5s -> 1s = 60 frames

	
	}
	
	// Make score running and compare the score to get star
	void Update () {
		if (!finishCounting) {
			score += scoreRunning;
			if (score > GameManager.instance.star1)
				Star1.SetActive (true);
			if (score > GameManager.instance.star2)
				Star2.SetActive (true);
			if (score > GameManager.instance.star3)
				Star3.SetActive (true);
			if (score >= GameManager.Score) {
				finishCounting = true;	//stop counting
				score = GameManager.Score;

				//when finish counting, enable those button for user choose
				Menu.SetActive (true);
				Restart.SetActive (true);
				if (!GameManager.instance.isFinishWorld)
					Next.SetActive (true);
			}
		
			Score.text = score + "";	
		}
	}
}
