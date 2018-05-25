using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryImage : MonoBehaviour {

	public UnityEvent OnStoryFinished;
	public UnityEvent OnGameFinished;

	public void AnimationFinished()
	{
		OnStoryFinished.Invoke ();
	}

	public void GameFinished()
	{
		OnGameFinished.Invoke ();
	}
}
