using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public static AudioClip[] clips;
	public AudioClip[] musicClips;

	private static AudioSource _audioSource;
	private static int _currentClip = 0;

	private static MusicManager instance = null;

	void Awake()
	{
		if (!instance) 
		{
			instance = this;
		} 
		else 
		{
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		clips = musicClips;

		_audioSource = GetComponent<AudioSource> ();
		_audioSource.clip = clips [0];
		_audioSource.Play ();
	}
	
	public static void NextSong()
	{
		_currentClip++;
		_audioSource.Stop ();
		_audioSource.clip = clips [_currentClip];
		_audioSource.Play ();
	}

	public static void PauseClip()
	{
		Debug.Log ("pause");
		_audioSource.Pause ();
	}

	public static void UnPauseClip()
	{
		_audioSource.UnPause ();
	}

	public static void ResetClips()
	{
		_currentClip = 0;
		_audioSource.Stop ();
		_audioSource.clip = clips [_currentClip];
		_audioSource.Play ();
	}
}
