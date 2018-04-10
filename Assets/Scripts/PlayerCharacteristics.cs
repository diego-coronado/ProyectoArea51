using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
	{
		Neutral, Fire, Ice
	};

public class PlayerCharacteristics : MonoBehaviour {

	public Material neutralMaterial;

	private Type _type;

	// Use this for initialization
	void Start () {
		_type = Type.Neutral;
	}
	
	public Type State {
		get { return _type; }
	}

	public void DisablePlayer()
	{
		GetComponent<Renderer>().material = neutralMaterial;
		_type = Type.Neutral;
	}

	public void EnablePlayer(Type type, Material newMaterial)
	{
		GetComponent<Renderer>().material = newMaterial;
		_type = type;
	}
}
