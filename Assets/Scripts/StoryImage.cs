using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryImage : MonoBehaviour {
	public LevelTrigger[] levelTriggers;

	private int _currentLvl = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AnimationFinished()
	{

		levelTriggers [_currentLvl].ChangeLevel ();
		_currentLvl++;
	}
}
