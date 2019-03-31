using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the currently selected object by adding a ui circle around it and updating it's size and position to match the selected object.
/// </summary>
public class ShowSelectedObject : MonoBehaviour {

	public GameObject showSelectedIndicator;
	private GameObject selectedObject;
	// Use this for initialization
	void Start () {
		selectedObject = LevelController.instance.selectedObject;
		showSelectedIndicator = Instantiate (showSelectedIndicator);
		showSelectedIndicator.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
		GameObject levelCanvas = gameObject;
		showSelectedIndicator.transform.SetParent (levelCanvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
			showSelectedIndicator.SetActive (false);
		} else {
			if (LevelController.instance.selectedObject != null) {
				//only update ui if the selected object has changed
				if (selectedObject != LevelController.instance.selectedObject) {
					selectedObject = LevelController.instance.selectedObject;
					UpdateUI ();
				}
				showSelectedIndicator.SetActive (true);
				gameObject.SetActive (true);
				showSelectedIndicator.transform.position = LevelController.instance.selectedObject.transform.position;
			} 
			//if selected object is null, hide the indicator
			else {
				showSelectedIndicator.SetActive (false);
				selectedObject = LevelController.instance.selectedObject;
			}
		}
	}

	/// <summary>
	/// Updates the selected object indicator, should be called anytime selected object changes.
	/// </summary>
	public void UpdateUI(){
		showSelectedIndicator.SetActive (true);
		showSelectedIndicator.transform.position = LevelController.instance.selectedObject.transform.position;
		Vector3 scale = LevelController.instance.selectedObject.transform.localScale;
		if (scale.x > scale.y) {
			showSelectedIndicator.transform.localScale = new Vector3 (scale.x, scale.x, scale.z);
		} else {
			showSelectedIndicator.transform.localScale = new Vector3 (scale.y, scale.y, scale.z);
		}
		Rect selectedObjectRect = LevelController.instance.selectedObject.GetComponent<RectTransform> ().rect;
		float width = 0;
		float height = 0;
		if (LevelController.instance.selectedObject.tag != "Glue") {
			width = selectedObjectRect.width + (selectedObjectRect.width * .5f);
			height = selectedObjectRect.height + (selectedObjectRect.height * .5f);
			if (height < width) {
				height = width;
			} else {
				width = height;
			}
		} else {
			width = selectedObjectRect.width * 2;
			height = selectedObjectRect.height * 2;
		}
		showSelectedIndicator.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height);
	}
}
