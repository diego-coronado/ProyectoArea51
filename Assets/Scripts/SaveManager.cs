using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {

	public GameObject player1, player2;
	public Transform cameraPos;
	public float cameraSize;
	public int levelTime;
	public Text timerText;
	public LevelTimer levelTimer;
	public bool deletePlayerPrefs;
	public static int currentLevel = 0;

	// Use this for initialization
	void Start () {
		if (deletePlayerPrefs)
			PlayerPrefs.DeleteAll();
		LoadCheckpoint();
	}

	public void LoadCheckpoint()
	{
		var player1Pos = player1.transform.position;
		player1Pos.x = PlayerPrefs.GetFloat("Player1X", player1.transform.position.x);
		player1Pos.y = PlayerPrefs.GetFloat("Player1Y", player1.transform.position.y);
		player1.transform.position = player1Pos;

		player1.GetComponent<PlayerElement>().DisablePlayer();
		
		var player2Pos = player2.transform.position;
		player2Pos.x = PlayerPrefs.GetFloat("Player2X", player2.transform.position.x);
		player2Pos.y = PlayerPrefs.GetFloat("Player2Y", player2.transform.position.y);
		player2.transform.position = player2Pos;

		player2.GetComponent<PlayerElement>().DisablePlayer();		
		
		var camera = Camera.main;
		var cameraPosVec = cameraPos.position;
		cameraPosVec.x = PlayerPrefs.GetFloat("CameraX", cameraPos.position.x);
		cameraPosVec.y = PlayerPrefs.GetFloat("CameraY", cameraPos.position.y);
		cameraPosVec.z = PlayerPrefs.GetFloat("CameraZ", cameraPos.position.z);
		camera.orthographicSize = PlayerPrefs.GetFloat("CameraSize", cameraSize);
		camera.transform.position = cameraPosVec;

		int oldLevelTime = PlayerPrefs.GetInt("LevelTime", levelTime);
        //oldLevelTime += 15;
		timerText.text = oldLevelTime.ToString();
		
		levelTimer.LevelMaxTime = oldLevelTime;

		currentLevel = PlayerPrefs.GetInt("CurrentLevel", currentLevel); 
	}
	
	public void SaveCheckpoint(int newLevelTime, Transform newCameraTransform, float newCameraSize)
	{
		this.cameraPos = newCameraTransform;
		this.levelTime = newLevelTime;
		this.cameraSize = newCameraSize;

		PlayerPrefs.SetFloat("CameraSize", cameraSize);
		PlayerPrefs.SetInt("LevelTime", levelTime);

		PlayerPrefs.SetFloat("Player1X", player1.transform.position.x);
		PlayerPrefs.SetFloat("Player1Y", player1.transform.position.y);

		PlayerPrefs.SetFloat("Player2X", player2.transform.position.x);
		PlayerPrefs.SetFloat("Player2Y", player2.transform.position.y);

		PlayerPrefs.SetFloat("CameraX", cameraPos.position.x);
		PlayerPrefs.SetFloat("CameraY", cameraPos.position.y);
		PlayerPrefs.SetFloat("CameraZ", cameraPos.position.z);

		PlayerPrefs.SetInt ("CurrentLevel", ++currentLevel);
	}
	
}
