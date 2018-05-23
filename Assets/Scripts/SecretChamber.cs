using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretChamber : MonoBehaviour {

	public Transform chamberCameraPosition;
	public float chamberCameraSize;

	public LevelTrigger[] levelTriggers;

	private int currentLevel = 1;

	// Use this for initialization
	void Start () {
		currentLevel = SaveManager.currentLevel == 0 ? 1 : SaveManager.currentLevel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MoveCameraToChamber()
	{
		Camera.main.transform.position = chamberCameraPosition.position;
		Camera.main.orthographicSize = chamberCameraSize;
	}

	void MoveCameraToNextLevel()
	{
		levelTriggers [currentLevel].MoveCameraToNextPosition();
	}

	void AnimationFinished()
	{
		Debug.Log (currentLevel);
		levelTriggers [currentLevel].ShowStory ();
		currentLevel++;
	}
}
