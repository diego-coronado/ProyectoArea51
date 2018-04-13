using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSphere : MonoBehaviour {

	[SerializeField] private string _newAnimationString;
	[SerializeField] private Sprite _newSprite;
	[SerializeField] private Type _newState;
	[SerializeField] private bool _shouldDestroy = true;

	//public GameObject neutralToUpgrade;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			var playerCharacteristics = other.gameObject.GetComponent<PlayerElement>();

			playerCharacteristics.EnablePlayer(_newState, _newAnimationString, _newSprite);
			if(_shouldDestroy)
				Destroy(gameObject);	
		}
		
	}
}
