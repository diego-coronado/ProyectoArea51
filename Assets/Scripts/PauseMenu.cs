using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {
    public LevelTimer levelTimer;

	// Use this for initialization
	void Start () {
		
	}

    public void ReloadLevel()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UnPauseLevel()
    {
        levelTimer.UnPause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
