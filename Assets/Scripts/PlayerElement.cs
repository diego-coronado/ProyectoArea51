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

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<PlayerElement>().State == OppositeElement())
			{
				Debug.Log("player collision");
				other.gameObject.GetComponent<PlayerElement>().DisablePlayer();
				this.DisablePlayer();
			}
		}
	}
}
