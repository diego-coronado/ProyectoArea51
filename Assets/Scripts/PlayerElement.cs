using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
	{
		NULL, Neutral, Fire, Ice
	};

public class PlayerElement : MonoBehaviour {

	public string neutralAnimation;

	private Type _type;
	private string _animationString;

	// Use this for initialization
	void Start () {
		_type = Type.Neutral;
	}

	public Type OppositeElement()
	{
		if (_type == Type.Fire) return Type.Ice;
		if (_type == Type.Ice) return Type.Fire;
		return Type.NULL;
	}
	
	public Type State {
		get { return _type; }
		set 
		{
			_type = value;
			if (_type == Type.Fire) gameObject.layer = 8;
			if (_type == Type.Ice) gameObject.layer = 10;
			if (_type == Type.Neutral) gameObject.layer = 11;			
						
		}
	}

	public void DisablePlayer()
	{
		GetComponent<Animator>().SetTrigger(neutralAnimation);
		_animationString = neutralAnimation;
		State = Type.Neutral;
	}

	public void EnablePlayer(Type type, string animationTriggerString)
	{
		GetComponent<Animator>().SetTrigger(animationTriggerString);
		_animationString = animationTriggerString;
		State = type;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			var playerElement = other.gameObject.GetComponent<PlayerElement>();

			if (playerElement.State == OppositeElement())
			{
				Debug.Log("player collision");
				playerElement.DisablePlayer();
				this.DisablePlayer();
			}

			if ((playerElement.State == Type.Neutral) && (_type != Type.Neutral))
			{
				playerElement.EnablePlayer(_type, _animationString);
			}
		}
	}
}
