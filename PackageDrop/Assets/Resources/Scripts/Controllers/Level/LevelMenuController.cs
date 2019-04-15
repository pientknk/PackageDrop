using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the flow between scenes using the various menus available in level and the main menu
/// </summary>
public class LevelMenuController : MonoBehaviour {


	public void NewGame(){
		SceneManager.LoadScene ("Level 1");
	}

	public void LoadNextLevel(int indexToUnlock){
		SceneManager.LoadScene ("Level " + indexToUnlock);
	}
	
	public void LoadLevelSelector(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("LevelSelector");
	}

	public void QuitToMainLevel(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("MainMenu");
	}

    public void RestartCurrentLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void LoadSettings(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Settings");
	}

	public void LoadTutorial(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Tutorial");
	}
}
