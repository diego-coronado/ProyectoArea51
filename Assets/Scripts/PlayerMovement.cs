using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private string _horizontalAxis;
	[SerializeField] private string _verticalAxis;

	public float speed;
	
	private bool _canControl = true;
	
	public bool CanControl 
	{
		get { return _canControl; }
		set { _canControl = value; }
	}

	private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (CanControl)
		{
			float h = Input.GetAxis(_horizontalAxis);
			float v = Input.GetAxis(_verticalAxis);

			Vector2 movement = new Vector2(h,v);

			_rigidbody.velocity = movement*speed;
		}
		else 
		{
			_rigidbody.velocity = Vector2.zero;
		}
		
	}
}
