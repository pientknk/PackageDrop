using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckForNextLevel : MonoBehaviour {

	private Button button;
	// Use this for initialization
	void Start () {
		button = gameObject.GetComponent<Button> ();
		button.interactable = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (LevelController.instance.starsEarned >= 2 && SceneManager.GetActiveScene().name != "Level 15") {
			button.interactable = true;
		}
	}
}
