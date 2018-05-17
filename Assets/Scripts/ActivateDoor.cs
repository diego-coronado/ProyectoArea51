using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		transform.Find("Door").gameObject.SetActive(true);
	}
}
