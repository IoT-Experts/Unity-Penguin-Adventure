using UnityEngine;
using System.Collections;
/*
 * This is SoundManager
 * In other script, you just need to call SoundManager.PlaySfx(AudioClip) to play the sound
*/
public class SoundManager : MonoBehaviour {
	public AudioClip[] musics;
	public AudioClip[] sounds;

	private static SoundManager instance;

	private AudioSource musicAudio;
	private AudioSource soundFx;

	//GET and SET
	public static float MusicVolume{
		set{ instance.musicAudio.volume = value; }
		get{ return instance.musicAudio.volume; }
	}
	public static float SoundVolume{
		set{ instance.soundFx.volume = value; }
		get{ return instance.soundFx.volume; }
	}
	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		musicAudio = gameObject.AddComponent<AudioSource> ();
		musicAudio.loop = true;
		musicAudio.volume = 0.5f;
		soundFx = gameObject.AddComponent<AudioSource> ();

		//Check auido and sound
		if (!GlobalValue.isMusic)
			musicAudio.volume = 0;
		if (!GlobalValue.isSound)
			soundFx.volume = 0;

		if (musics.Length > 0)
			PlayMusic (musics [Random.Range (0, musics.Length)]);
	}

	public static void PlaySfx(AudioClip clip){
		instance.PlaySound(clip, instance.soundFx);
	}
	public static void PlaySfx(AudioClip clip, float volume){
		instance.PlaySound(clip, instance.soundFx, volume);
	}
	
	public static void PlaySfx(string nameSound){
		if (instance == null) {
			Debug.Log ("No SoundManager found");
			return;
		}
		instance.PlaySound (nameSound, instance.sounds, instance.soundFx);
	}

	public static void PlayMusic(string nameMusic){
		if (instance == null) {
			Debug.Log ("No SoundManager found");
			return;
		}
		instance.PlaySound (nameMusic, instance.musics, instance.musicAudio);
	}
	public static void PlayMusic(AudioClip clip){
		instance.PlaySound (clip, instance.musicAudio);
	}

	private void PlaySound(string name, AudioClip[] pool, AudioSource audio){
		foreach (AudioClip clip in pool) {
			if (clip.name == name) {
				PlaySound (clip, audio);
				return;
			}
		}
		Debug.Log ("No audio found, check the name correctly");
	}

	private void PlayMusic(AudioClip clip, AudioSource audio){
		audio.clip = clip;
		audio.Play ();
	}

	private void PlaySound(AudioClip clip,AudioSource audioOut){
//		audioOut.clip = clip;
//		audioOut.Play ();
		audioOut.PlayOneShot (clip, SoundVolume);
	}

	private void PlaySound(AudioClip clip,AudioSource audioOut, float volume){
		//		audioOut.clip = clip;
		//		audioOut.Play ();
		audioOut.PlayOneShot (clip, SoundVolume*volume);
	}
}
