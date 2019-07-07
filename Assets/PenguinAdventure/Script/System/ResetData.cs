using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour {

	public void Reset(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void UnlockAll(){
		PlayerPrefs.SetInt ("WorldReached", int.MaxValue);
		PlayerPrefs.SetInt ("World1" + "HighestLevel", int.MaxValue);
		PlayerPrefs.SetInt ("World2" + "HighestLevel", int.MaxValue);
		PlayerPrefs.SetInt ("World3" + "HighestLevel", int.MaxValue);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
