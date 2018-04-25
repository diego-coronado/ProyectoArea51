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
				GetComponent<SpriteRenderer>().color = Color.blue;
				_isFreezing = false;
				gameObject.layer = 10;
				OnFreeze.Invoke();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerElement>().State == Type.Ice && _state == Type.Neutral)
		{
			StartFreezing();
		}
	}

	void StartFreezing()
	{
		GetComponent<Collider2D>().enabled = false;
		_isFreezing = true;
	}

}
