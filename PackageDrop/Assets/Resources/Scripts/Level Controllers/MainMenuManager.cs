using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the availability of the buttons in the main menu.
/// </summary>
public class MainMenuManager : MonoBehaviour {

	public Button continueButton;

	void Start () {
		if (PlayerPrefs.HasKey ("Level 1 stars")) {
			int stars = PlayerPrefs.GetInt ("Level 1 stars");
			if (stars >= 1) {
				continueButton.interactable = true;
			} else {
				continueButton.interactable = false;
			}
		} else {
			continueButton.interactable = false;
		}
	}
}
