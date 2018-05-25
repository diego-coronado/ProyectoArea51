using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour {

	public Animator _animator;

	private int _passedPlayers = 0;

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerMovement>().CanControl = false;
			//other.gameObject.GetComponent<PlayerElement>().DisablePlayer();	

			_passedPlayers++;

			if (_passedPlayers == 2) 
			{
				_animator.gameObject.SetActive (true);
				_animator.SetTrigger ("endgame");
			}
		}
	}

	public void ReturnToTitleScreen()
	{
		SceneManager.LoadScene ("TitleScreen");
	}
}
