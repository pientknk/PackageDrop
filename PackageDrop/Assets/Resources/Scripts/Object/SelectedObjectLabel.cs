using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the selected object label to show the name of what is selected.
/// </summary>
public class SelectedObjectLabel : MonoBehaviour {

	private Text label;
	// Use this for initialization
	void Start () {
		//get text to be able to update it and set the entire panel to be inactive to hide it upon start
		label = GetComponent<Text> ();
		transform.parent.parent.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelController.instance.selectedObject != null) {
			label.text = "Selected: " + LevelController.instance.selectedObject.tag;
		} else {
			label.text = "Selected: None"; 
		}
	}
}
