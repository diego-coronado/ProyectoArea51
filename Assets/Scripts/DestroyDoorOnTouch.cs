using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoorOnTouch : MonoBehaviour {

	//public GameObject sphere;

	[SerializeField] private float _meltTime = 2.0f;
	[SerializeField] private Type _meltState;

	private float _time = 0;
	private bool _runTimer;
	private bool _beingDestroyed = false;

	private Animator _animator;

	void Start()
	{
		_animator = GetComponent<Animator> ();
	}

	void Update()
	{
		/*if (_runTimer)
		{
			_time += Time.deltaTime;
			if(_time >= _meltTime)
			{
				Destroy(gameObject);
			}
		}*/
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if (!_beingDestroyed) 
			{
				var playerCharacteristics = other.gameObject.GetComponent<PlayerElement>();

				if(playerCharacteristics.State == _meltState){
					//_runTimer = true;	
					_beingDestroyed = true;
					playerCharacteristics.DisablePlayer();
					_animator.SetTrigger ("animate");
				}
			}
		}
	}

	void DestroyDoor()
	{
		Destroy (gameObject);
	}
}
