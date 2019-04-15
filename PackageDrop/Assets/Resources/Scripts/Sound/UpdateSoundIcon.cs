using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSoundIcon : MonoBehaviour {

	public Sprite sound;
	public Sprite muteSound;
	private Image image;
	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
		if (GameController.sounds) {
			image.sprite = sound;
		} else {
			image.sprite = muteSound;
		}
	}
}
