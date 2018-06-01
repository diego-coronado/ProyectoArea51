using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Freezeable : MonoBehaviour {

	public float maxFreezeTime = 0f;
	public UnityEvent OnFreeze;

	private bool _isFreezing = false;
	private float _freezingTime = 0;
	private Type _state = Type.Neutral;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_isFreezing)
		{
			_freezingTime += Time.deltaTime;

			if (_freezingTime >= maxFreezeTime)
			{
				_state = Type.Ice;
				_isFreezing = false;
				gameObject.layer = 10;
				OnFreeze.Invoke();
			}
		}
	}

	//Esto es para el objeto hijo, it works, don't know why, it's magic
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			var playerElement = col.gameObject.GetComponent<PlayerElement>();

			if (playerElement.State == Type.Ice && _state == Type.Neutral)
			{
				StartFreezing();				
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			var playerElement = col.gameObject.GetComponent<PlayerElement>();

			if (playerElement.State == Type.Fire && _state == Type.Ice)
			{
				playerElement.DisablePlayer();
			}

			else if (playerElement.State == Type.Neutral && _state == Type.Ice)
			{
				playerElement.EnablePlayer(Type.Ice, "ice");
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			var playerElement = col.gameObject.GetComponent<PlayerElement>();

			if (playerElement.State == Type.Fire && _state == Type.Ice)
			{
				playerElement.DisablePlayer();
			}
		}
	}

	void StartFreezing()
	{
		//GetComponent<Collider2D>().enabled = false;
		_isFreezing = true;
		_state = Type.Ice;
		GetComponent<Collider2D> ().isTrigger = true;
	}

}
