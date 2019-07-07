using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour {
	public Text bullets;
	public Text stars;
	public GameObject tutorial;
	[Header("Heart")]
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public GameObject heart4;
	public GameObject heart5;
	public GameObject heart6;
	public GameObject heart7;

	private float reduceHeartTime = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (ReduceHeart (reduceHeartTime));
		CheckHeart ();
	}
	
	// Update is called once per frame
	void Update () {
		stars.text = GameManager.Stars + "";
		bullets.text = GameManager.Bullets + "";
		CheckHeart ();
		if (Input.anyKeyDown) {
			tutorial.SetActive (false);
		}
	}

	IEnumerator ReduceHeart(float time){
		yield return new WaitForSeconds (time);
		if (GameManager.CurrentState == GameManager.GameState.Playing)
			GameManager.Hearts--;
		
		if (GameManager.Hearts <= 0)
			GameManager.instance.GameOver ();
		else
			StartCoroutine (ReduceHeart (reduceHeartTime));
		


	}

	public void CheckHeart(){
		switch (GameManager.Hearts) {
		case 1:
			heart1.SetActive (true);
			heart2.SetActive (false);
			heart3.SetActive (false);
			heart4.SetActive (false);
			heart5.SetActive (false);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		case 2:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (false);
			heart4.SetActive (false);
			heart5.SetActive (false);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		case 3:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (false);
			heart5.SetActive (false);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		case 4:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			heart5.SetActive (false);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		case 5:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			heart5.SetActive (true);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		case 6:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			heart5.SetActive (true);
			heart6.SetActive (true);
			heart7.SetActive (false);
			break;
		case 7:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			heart5.SetActive (true);
			heart6.SetActive (true);
			heart7.SetActive (true);
			break;
		default:
			heart1.SetActive (false);
			heart2.SetActive (false);
			heart3.SetActive (false);
			heart4.SetActive (false);
			heart5.SetActive (false);
			heart6.SetActive (false);
			heart7.SetActive (false);
			break;
		}
	}
}
