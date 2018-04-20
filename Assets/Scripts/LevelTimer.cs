using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	public Text lvlTimer;
	
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

	// Use this for initialization
	void Start () {
		_timeLeft = _levelMaxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (_runTimer)
		{
			_timeLeft -= Time.deltaTime;

			lvlTimer.text = "Tiempo restante: " + _timeLeft.ToString("0.00");;

			if (_timeLeft <= 0)
			{
				GetComponent<SaveManager>().LoadCheckpoint();
				Debug.Log("GG WP");
			}
		}
	}
}
