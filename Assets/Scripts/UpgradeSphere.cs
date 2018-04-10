using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSphere : MonoBehaviour {

	[SerializeField] private Material _newMaterial;
	[SerializeField] private Type _newState;
	[SerializeField] private bool _shouldDestroy = true;

	//public GameObject neutralToUpgrade;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			var playerCharacteristics = other.gameObject.GetComponent<PlayerCharacteristics>();

			if(playerCharacteristics.State == Type.Neutral)
			{
				playerCharacteristics.EnablePlayer(_newState, _newMaterial);
				if(_shouldDestroy)
					Destroy(gameObject);
			}	
		}
		
	}
}
