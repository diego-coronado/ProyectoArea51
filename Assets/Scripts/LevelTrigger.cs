using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour {

	public Transform newCameraPosition;
	public GameObject levelManager;
	public float newCameraSize;
	public SaveManager saveManager;

	public Animator chamberAnimator;
	public Animator storyAnimator;
	public string storyTrigger;

	private bool animationStarted = false;

	[SerializeField] private int _nextLevelMaxTime;
	[SerializeField] private bool _runChamberAnimation = true;

	private int _passedPlayers = 0;
	private bool _passedLevel = false;
	private static GameObject[] _players;

	void Start()
	{
		if (_players == null)
			_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!_runChamberAnimation && _passedLevel) 
		{
			var camPos = Camera.main.transform.position;
			Camera.main.transform.position = Vector3.Lerp (camPos, newCameraPosition.position, 5 * Time.deltaTime);

			var camSize = Camera.main.orthographicSize;
			Camera.main.orthographicSize = Mathf.Lerp (camSize, newCameraSize, 5 * Time.deltaTime);

			if (Vector3.Distance (camPos, Camera.main.transform.position) <= 0.2f) 
			{
				ChangeLevel ();
			}
		}
	}

	public void MoveCameraToNextPosition()
	{
		Camera.main.transform.position = newCameraPosition.position;
		Camera.main.orthographicSize = newCameraSize;
	}


	public void ShowStory()
	{
		Debug.Log (storyTrigger);
		//storyAnimator.gameObject.SetActive (true);
		storyAnimator.SetTrigger (storyTrigger);
	}

	public void ChangeLevel()
	{
		foreach(var player in _players)
		{
			player.GetComponent<PlayerMovement>().CanControl = true;
		}

		levelManager.GetComponent<LevelTimer>().LevelMaxTime = _nextLevelMaxTime;
		levelManager.GetComponent<LevelTimer>().RunTimer = true;

		GetComponent<Collider2D>().isTrigger = false;

		this.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerMovement>().CanControl = false;
			other.gameObject.GetComponent<PlayerElement>().DisablePlayer();	

			_passedPlayers++;

			if (_passedPlayers == 2) 
			{
				_passedLevel = true;

				levelManager.GetComponent<LevelTimer>().RunTimer = false;

				if (saveManager)
					saveManager.SaveCheckpoint(_nextLevelMaxTime, newCameraPosition, newCameraSize);

				if (_runChamberAnimation) 
				{
					chamberAnimator.SetTrigger ("start");
					Debug.Log ("start animation");
				} 
			}
		}
	}
}
