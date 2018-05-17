using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {

	public float maxBurnTime = 2f;
	public float burnSpreadTime = 1f;
	public float boxCastSize = 1.1f;
	
	private bool _isBurning = false;
	private float _burningTime = 0;
	private Animator _animator;

	// Use this for initialization
	void Start () 
	{
		_animator = GetComponent<Animator>();
		if (burnSpreadTime >= maxBurnTime) burnSpreadTime = maxBurnTime / 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (_isBurning)
		{
			_burningTime += Time.deltaTime;

			if (Mathf.Abs(_burningTime - burnSpreadTime) <= 0.1f)
			{
				SpreadFire();
			}

			if (_burningTime >= maxBurnTime)
			{
				_animator.SetTrigger("destroyTrigger");
				Invoke("DestroyEvent", 0.5f);
			}
		}
	}

	void SpreadFire()
	{
		Collider2D[] hits = new Collider2D[8];
		var boxSize = new Vector2(boxCastSize, boxCastSize);
		var contact = new ContactFilter2D();
		Physics2D.OverlapBox(transform.position, boxSize, 0, contact.NoFilter(), hits);

		foreach(var hit in hits)
		{
			if (hit)
			{
				var flammableScript = hit.gameObject.GetComponent<Flammable>();
				
				if (flammableScript)
				{
					flammableScript.StartBurning();
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" && 
			!_isBurning &&
			other.gameObject.GetComponent<PlayerElement>().State == Type.Fire)
		{
			StartBurning();
		}
	}

	void StartBurning()
	{
		_isBurning = true;
		_animator.SetTrigger("startTrigger");
		//change sprite or something
	}

	void DestroyEvent()
	{
		Destroy(gameObject);
	}
}
