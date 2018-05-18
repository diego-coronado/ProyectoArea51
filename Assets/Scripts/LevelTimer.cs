using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour {

	public Text lvlTimer;
	public GameObject player1;
	public GameObject player2;
    public GameObject pauseMenu;
	
	[SerializeField] private float _levelMaxTime = 30;
	public float LevelMaxTime
	{
		get { return _levelMaxTime; }
		set { 
			_levelMaxTime = value;
			_timeLeft = _levelMaxTime;
		}
	}

	private bool _runTimer = true;
	public bool RunTimer
	{
		get { return _runTimer; }
		set { _runTimer = value; }
	}

	private float _timeLeft;

	private bool _paused;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        _timeLeft = _levelMaxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!_paused)  
			{
				_paused = true;
				_runTimer = false;
				Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }

		if (_runTimer)
		{
			_timeLeft -= Time.deltaTime;

			lvlTimer.text = "Tiempo restante: " + _timeLeft.ToString("0.00");;

			if (_timeLeft <= 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				//GetComponent<SaveManager>().LoadCheckpoint();
				Debug.Log("GG WP");
			}
		}
	}

    public void UnPause()
    {
        _paused = false;
        _runTimer = true;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
