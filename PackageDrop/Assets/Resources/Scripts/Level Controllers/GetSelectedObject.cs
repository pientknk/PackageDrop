using UnityEngine;

/// <summary>
/// Changes the selected object to whatever the user clicked on
/// </summary>
public class GetSelectedObject : MonoBehaviour {

	void OnMouseDown(){
		LevelController.instance.selectedObject = gameObject;
		LevelController.instance.objectPanel.SetActive (true);
	}
}
