using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMusicIcon : MonoBehaviour {

	public Sprite music;
	public Sprite muteMusic;
	private Image image;
	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
		if (GameController.music) {
			image.sprite = music;
		} else {
			image.sprite = muteMusic;
		}
	}
}
