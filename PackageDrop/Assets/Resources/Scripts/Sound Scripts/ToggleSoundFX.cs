using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toggle SFX during gameplay
/// </summary>
public class ToggleSoundFX : MonoBehaviour {

	public AudioSource explode;
	public AudioSource shatter;
	public AudioSource shatter2;

	void Start() {
		explode.playOnAwake = GameController.sounds;
		shatter.playOnAwake = GameController.sounds;
		shatter2.playOnAwake = GameController.sounds;
	}

	public void toggle (Button buttonPressed) {
		if (!GameController.sounds) {
			explode.playOnAwake = !GameController.sounds;
			shatter.playOnAwake = !GameController.sounds;
			shatter2.playOnAwake = !GameController.sounds;
			GameController.sounds = !GameController.sounds;
		} else {
			explode.playOnAwake = GameController.sounds;
			shatter.playOnAwake = GameController.sounds;
			shatter2.playOnAwake = GameController.sounds;
			GameController.sounds = !GameController.sounds;
		}
	}
}
