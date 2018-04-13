using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
	{
		Neutral, Fire, Ice
	};

public class PlayerElement : MonoBehaviour {

	public string neutralAnimation;

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
		GetComponent<Animator>().SetTrigger(neutralAnimation);
		_type = Type.Neutral;
	}

	public void EnablePlayer(Type type, string animationTriggerString, Sprite newSprite)
	{
		GetComponent<Animator>().SetTrigger(animationTriggerString);
		_type = type;
	}
}
