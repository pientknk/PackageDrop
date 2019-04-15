using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toggles the music during gameplay
/// </summary>
public class ToggleMute : MonoBehaviour {

	AudioSource music;

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource> ();
		if (GameController.music) {
			music.UnPause ();
		} else {
			music.Pause ();
		}
	}
	
	// Update is called once per frame
	public void toggle (Button buttonPressed) {
		if(music.isPlaying) {
			music.Pause();
			GameController.music = !GameController.music;
		} else {
			music.UnPause();
			GameController.music = !GameController.music;
		}
	}
}
