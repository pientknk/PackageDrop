using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages a dialogue panel and canvas that is used to introduce each level with images and the associated paragraph.
/// </summary>
public class Dialogue : MonoBehaviour {

	public Image dialogueImage;
	public Text dialogue;
	public Image moreTextIndicator;
	/// <summary>
	/// The list holding all parts of the dialogue
	/// </summary>
	public List<string> dialogueParts;
	/// <summary>
	/// The list holding all the images to go along with the dialogue
	/// </summary>
	public List<Sprite> spriteParts;

	private Sprite currentSpritePart;
	private int index = 0;
	private float timer = 0.0f;
	/// <summary>
	/// The time between the more text indicator toggling on and off
	/// </summary>
	private float timeBetweenSwitch = 1.0f;

	// Use this for initialization
	void Start () {
		LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
		for (int i = 0; i < dialogueParts.Count; i++) {
			string text = dialogueParts [i];
			text = text.Replace ("\\n", "\n");
			dialogueParts [i] = text;

		}
		dialogue.text = dialogueParts [index];
		if (spriteParts [index] != null) {
			dialogueImage.sprite = spriteParts [index];
		}
		CheckForMoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && index < dialogueParts.Count) {
			index++;
			if (index == dialogueParts.Count) {
				LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = true;
				Destroy (gameObject);
			} else {
				if (spriteParts [index] != null) {
					dialogueImage.sprite = spriteParts [index];
				}
				ShowDialogue (index);
				CheckForMoreText ();
			}
		}
		timer += Time.unscaledDeltaTime;
		if (timer >= timeBetweenSwitch) {
			timer = 0.0f;
			ToggleMoreTextIndicator ();
		}
	}
		
	/// <summary>
	/// sets the text of the dialogue panel to the index of the text array
	/// </summary>
	/// <param name="index">Index.</param>
	private void ShowDialogue(int index){
		dialogue.text = dialogueParts [index];
	}

	/// <summary>
	/// shows a more text indicator if there is more text for the dialogue
	/// </summary>
	private void CheckForMoreText(){
		if (dialogueParts.Count > index + 1) {
			moreTextIndicator.gameObject.SetActive (true);
		} else {
			moreTextIndicator.gameObject.SetActive (false);
		}
	}

	/// <summary>
	/// Toggles the more text indicator.
	/// </summary>
	private void ToggleMoreTextIndicator(){
		if (dialogueParts.Count > index + 1) {
			moreTextIndicator.gameObject.SetActive (!moreTextIndicator.gameObject.activeSelf);
		}
	}
}
