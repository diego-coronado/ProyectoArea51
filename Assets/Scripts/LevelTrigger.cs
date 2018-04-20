using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	public Transform newCameraPosition;
	public GameObject levelManager;
	public int newCameraSize;
	public SaveManager saveManager;

	[SerializeField] private int _nextLevelMaxTime;

	private int _passedPlayers = 0;
	private bool _passedLevel = false;
	private static GameObject[] _players;

	void Start()
	{
		if (_players == null)
			_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (_passedLevel)
		{
			var cameraPosition = Camera.main.transform.position;
			Camera.main.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition.position, 5 * Time.deltaTime);

			var currentCameraSize = Camera.main.orthographicSize;
			Camera.main.orthographicSize = Mathf.Lerp(currentCameraSize, newCameraSize, 5 * Time.deltaTime);

			if (Vector3.Distance(Camera.main.transform.position, newCameraPosition.position) <= 0.2f)
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
		}
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

				Debug.Log("Lvl completed");
				//change lvl
			}
		}
	}
}
