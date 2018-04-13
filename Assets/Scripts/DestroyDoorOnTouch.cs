using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoorOnTouch : MonoBehaviour {

	//public GameObject sphere;

	[SerializeField] private float _meltTime = 2.0f;
	[SerializeField] private Type _meltState;

	private float _time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			var playerCharacteristics = other.gameObject.GetComponent<PlayerElement>();
			
			if(playerCharacteristics.State == _meltState){
				_time += Time.deltaTime;
				if(_time >= _meltTime)
				{
					playerCharacteristics.DisablePlayer();
					Destroy(gameObject);
				}
			}
		}
		
	} 
}
