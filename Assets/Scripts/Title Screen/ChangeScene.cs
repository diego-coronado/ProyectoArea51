using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	[SerializeField] private string _sceneName;

	public Image instructionImage;
	public Image creditImage;
	public Button backInstructionBtn;
	public Button backCreditBtn;

	public void ChangeLevel()
	{
		SceneManager.LoadScene (_sceneName);
	}

	public void ShowInstructions()
	{
		instructionImage.gameObject.SetActive (true);
		backInstructionBtn.gameObject.SetActive (true);
	}

	public void HideInstructions()
	{
		backInstructionBtn.gameObject.SetActive (false);
		instructionImage.gameObject.SetActive (false);
	}

	public void ShowCredits()
	{
		creditImage.gameObject.SetActive (true);
		backCreditBtn.gameObject.SetActive (true);
	}

	public void HideCredits()
	{
		creditImage.gameObject.SetActive (false);
		backCreditBtn.gameObject.SetActive (false);
	}
}
